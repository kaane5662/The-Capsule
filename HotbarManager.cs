using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class HotbarManager : MonoBehaviour
{
    // Start is called before the first frame update

    private List<HotbarSlot> slots = new List<HotbarSlot>();
    private int lastIndex = -1;
    private GameObject equippedObj;
    private Transform hand;

    private void Start(){
        hand = transform.Find("Hand");
    }
    public void addItem(GameObject obj, ItemData data, bool isStackable){
        //attempt to find a slot with the same item data
        int sameSlotDataIndex = -1;
        Debug.Log("arrived here");
        for(int i = 0; i < slots.Count; i++){
            if(slots[i].getItemData().Equals(data)){
                sameSlotDataIndex = i;
                break;
            }
        }
        //add the gameobject to the slot stack with the same item data, otherwise create a new slot
        if(sameSlotDataIndex >= 0){
            if(!isStackable){return;}
            slots[sameSlotDataIndex].addToStack(obj);
        }else{
            HotbarSlot slot = new HotbarSlot(obj, data);
            slots.Add(slot);
            Debug.Log("Slot count: "+slots.Count);
        }
        obj.SetActive(false);
    }

    //Potential problem: references directly equal to one another, use a temp variable and set the recent variable to null
    //use the slotIndex to get the stack of item
    private void equipItem(int slotIndex){
        if(slotIndex < slots.Count)
            equippedObj = slots[slotIndex].getItemFromStack();
            equippedObj.SetActive(true);
            equippedObj.transform.position = hand.position;
            equippedObj.transform.SetParent(hand);
            lastIndex = slotIndex;
    }

    private void unEquipItem(){
        if(equippedObj != null){
            equippedObj.SetActive(false);
            equippedObj.transform.SetParent(null);
            slots[lastIndex].addToStack(equippedObj);
            equippedObj = null;
            lastIndex = -1;
        }  
    }

    public void useItem(){
        if(equippedObj != null){
            Destroy(equippedObj);
            if(slots[lastIndex].getStackLength() <= 0){
                Debug.Log("deleting slot");
                slots.RemoveAt(lastIndex);
            }
            lastIndex = -1;
        }
    }

    private void Update(){
        for(int i = 0; i < slots.Count; i++){
            if(Input.GetKeyDown(i+1+"")){
                //if the player selects the same slot unequip the item
                if(lastIndex == i){
                    unEquipItem();
                    return;
                }
                unEquipItem();
                equipItem(i); 
            }

        }
    }


    

    
}

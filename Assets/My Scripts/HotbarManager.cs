using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class MyStringEvent : UnityEvent<string>
{}
public class HotbarManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;

    private List<HotbarSlot> slots = new List<HotbarSlot>();
    private int hotbarLength = 8;
    private bool isEquipped = false;
    private int lastIndex;
    private GameObject equippedObj;
    private PlayerHandManager hand;

    private void Start(){
        hand  = player.GetComponentInChildren<PlayerHandManager>();
    }

    public void addItem(GameObject obj, ItemData data){
        //attempt to find a slot with the same item data
        obj.SetActive(false);
        int sameSlotDataIndex = -1;
        for(int i = 0; i < slots.Count; i++){
            if(slots[i].getItemData().Equals(data)){
                sameSlotDataIndex = i;
                return;
            }
        }
        //add the gameobject to the slot stack with the same item data, otherwise create a new slot
        if(sameSlotDataIndex >= 0){
            slots[sameSlotDataIndex].addToStack(obj);
        }else{
            HotbarSlot slot = new HotbarSlot(obj, data);
            slots.Add(slot);
            Debug.Log("Slot count: "+slots.Count);
        }
    }

    //Potential problem: references directly equal to one another, use a temp variable and set the recent variable to null
    //use the slotIndex to get the stack of item
    private void equipItem(int slotIndex){
        if(slotIndex < slots.Count)
            equippedObj = slots[slotIndex].getItemFromStack();
            Debug.Log("Equipped Object: "+equippedObj);
            hand.updateHand(5,.25f, equippedObj);
            isEquipped = true;
    }

    private void unEquipItem(){
        if(isEquipped && equippedObj && lastIndex < slots.Count){
            hand.removeHand();
            slots[lastIndex].addToStack(equippedObj);
            isEquipped = false;
        }     
    }

    private void dropItem(){
        if(lastIndex < slots.Count && isEquipped){
           
        }
    }

    void Update(){
        for(int i = 0; i < 8; i++){
            if(Input.GetKeyDown(KeyCode.Alpha1)){
                //if the player selects the same slot unequip the item
                if(isEquipped && lastIndex == i){
                    unEquipItem();
                    return;
                }else{
                    unEquipItem();
                    equipItem(i);
                }
                
            }
            if(Input.GetKeyDown(KeyCode.Backspace)){
                dropItem();
            }  
        }
    }


    

    
}

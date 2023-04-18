using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;


public class InventoryManager: MonoBehaviour{

    public GameObject inventoryUI;

    public GameObject inventorySlot;

    UnityEvent addLoadout;

    private bool isActive = false;

    private List<InventorySlot> InventorySlots = new List<InventorySlot>();

    public Button button;


    //testing purposes
    static int num = 1;

    void remove(GameObject inventoryItem, Transform player, GameObject itemObject, InventorySlot slot){
        PlayerController playerController = player.GetComponent<PlayerController>();
        GameObject recievedItem =  slot.removeItem();
        Debug.Log("Removing object");
        if(slot.itemCount <= 0){
            Destroy(inventoryItem, .1f);
            InventorySlots.Remove(slot);
        }
        recievedItem.SetActive(true);
        // playerController.dropItem(recievedItem);

        
    }

    public void sendEquip(GameObject item, Transform player){
        PlayerController playerController = player.GetComponent<PlayerController>();
        item.SetActive(true);
        if(Input.GetKey(KeyCode.F)){
            Debug.Log("Equipping");
        }
        Debug.Log("Equipping item");
        // playerController.equipItem(item);
    }




     public void addItem(ItemData data, Transform player, GameObject item){

        bool itemStackExists = false;
        int index = -1;
        for(int i = 0; i < InventorySlots.Count; i++){
            Debug.Log(InventorySlots[i].data);
            Debug.Log(data);
            if(InventorySlots[i].data.Equals(data)){
                Debug.Log("Item of type already exists");
                itemStackExists = true;
                index = i;
                break;
            }
        }
        if(!itemStackExists){
            GameObject newItemSlot = Instantiate(inventorySlot, inventoryUI.transform);
            Button[] buttons = newItemSlot.GetComponentsInChildren<Button>();
            TextMeshProUGUI itemCountText = newItemSlot.GetComponentsInChildren<TextMeshProUGUI>()[2];
            InventorySlot newSlot = new InventorySlot(data, item, itemCountText);
            buttons[1].onClick.AddListener(delegate{remove(newItemSlot, player, item, newSlot);}); //remove
            buttons[0].GetComponentInChildren<TextMeshProUGUI>().text = data.itemName;
            buttons[0].onClick.AddListener(delegate{sendEquip(item, player);}); //equip
            InventorySlots.Add(newSlot);
        }else if(index != -1){
            InventorySlots[index].addItemOfSameType(item);
        }
        item.SetActive(false);       
        num++;
        
    }

    void Update(){
        
    }
    
    


}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject heldItem;
    bool isEquipped = false;
    public GameObject HotBar;

    public GameObject itemHand;

    public GameObject pickupPrompt;

    private HotbarManager hotbarManager;

    private int originalSlot = 0;

    
    void Start()
    {
        hotbarManager = HotBar.GetComponent<HotbarManager>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // void deEquipLastItem(){
   
    //     hotbarManager.addItemBack(originalSlot, heldItem);
    //     isEquipped = false;
 
    // }


    void equipItem(GameObject _item){
        if(heldItem){
            Debug.Log(_item);
            Debug.Log("This runs when an item is actually returned");
            _item.SetActive(true);
            _item.transform.SetParent(itemHand.transform);
            _item.transform.position = itemHand.transform.position;
            isEquipped = true;
        }
    }
    // void getItem(int index){
    //     Debug.Log("Fetching Item");
    //     if(!isEquipped){
    //         GameObject item = hotbarManager.getItemFromSlot(index);
    //         if(item != null)
    //             heldItem = item;
    //             originalSlot = index;
    //             equipItem(item);
    //     }

    // }

    // void activatePrompt(GameObject _item, ItemData _itemData){
    //     pickupPrompt.SetActive(true);
    //     if(Input.GetKeyDown(KeyCode.E)){
    //         hotbarManager.addNewItem(_item, _itemData);
    //         Debug.Log("Adding new item");
    //         _item.SetActive(false);
    //     }
    // }


    // void checkItemPickUp(){
    //     RaycastHit hit;
    //     if(Physics.Raycast(transform.position, transform.forward, out hit, 5f)){
    //         if(hit.transform.GetComponent<Item>()){
    //             if(hit.transform.gameObject == heldItem){return;}
    //             Item item = hit.transform.GetComponent<Item>();
    //             ItemData itemData = item.getData();
    //             activatePrompt(hit.transform.gameObject, itemData);
    //             return;
    //         }
    //     }
    //     pickupPrompt.SetActive(false);
    // }

    private void checkLevers(){

    }


    void OnTriggerEnter(Collider hit){
        if(hit.GetComponent<LeverManager>()){
            //is a lever
            
        }
        if(hit.GetComponent<Item>()){
            //is a item
        }
    }

    // Update is called once per frame
    void Update()
    {
        // checkItemPickUp();
        // checkInteractionEvent();
        // if(Input.GetKeyDown(KeyCode.Alpha1)){
        //     if(isEquipped){
        //         deEquipLastItem();
        //         return;
        //     }
        //     getItem(0);
        // }
        // if(Input.GetKeyDown(KeyCode.Alpha2)){
        //     if(isEquipped){
        //         deEquipLastItem();
        //         return;
        //     }
        //     getItem(1);
        // }
        // if(Input.GetKeyDown(KeyCode.Alpha3)){
            
        // }
        // if(Input.GetKeyDown(KeyCode.Alpha4)){
            
        // }
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerPickupController: MonoBehaviour
{   
    public Transform cam;
    public float pickUpRange = 15f;
    private HotbarManager hotbarManager;
    private void Start(){
        hotbarManager = transform.GetComponent<HotbarManager>();
    }
    private void displayPrompt(){
        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.forward, out hit, pickUpRange)){
            if(hit.transform.GetComponent<Item>()){
                Item item = hit.transform.GetComponent<Item>();
                if(item.itemData){
                    Debug.Log("Is an item");
                    if(Input.GetKeyDown(KeyCode.E)){
                        hotbarManager.addItem(hit.transform.gameObject, item.getData());
                    }
                }
            }
        }
    }

    private void Update(){
        displayPrompt();
    }
}

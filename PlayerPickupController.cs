using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerPickupController: MonoBehaviour
{   
    public Transform cam;
    public float pickUpRange = 15f;
    private void checkItems(){
        RaycastHit hit;
        if(Physics.Raycast(cam.position, cam.forward, out hit, pickUpRange)){
            Item isItem = hit.transform.GetComponent<Item>();
            if(isItem){
                isItem.setTextPromptActive(true);
                if(Input.GetKeyDown(KeyCode.E)){
                    isItem.pickUp(transform);
                }
            }
        }
    }
    private void checkInteractions(){
        RaycastHit hit;
        if(Physics.Raycast(cam.position, cam.forward, out hit, pickUpRange)){
            IInteractable interactable = hit.transform.GetComponent<IInteractable>();
            // Debug.Log(interactable);
            if(interactable != null){
                // Debug.Log("An interaction");
                interactable.setTextPromptActive(true);
                if(Input.GetKeyDown(KeyCode.E)){
                    interactable.interact(transform);
                }
            }
        }
    }

    private void Update(){
        checkInteractions();
        checkItems();
    }
}

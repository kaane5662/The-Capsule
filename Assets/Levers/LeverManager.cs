using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
[System.Serializable]

public class LeverManager : MonoBehaviour
{
    // Start is called before the first frame update
   

    private bool isPulled = false;

    private string status = "Pull lever[E]";
    
    private Transform player;
    private FloatingText prompt;
    private void Start(){
        prompt = transform.parent.GetComponentInChildren<FloatingText>();
        prompt.updateParent();
        prompt.updateText(status);
        prompt.enableText(false);
    }
    private void pullLever(){
        Debug.Log("Pulled lever");
        DoorEventManager.current.pullLever();
        isPulled = true;
        prompt.enableText(false);
        prompt.updateText("Lever pulled");
    }

    private void Update(){
        if(player == null){return;}
        if(Input.GetKeyDown(KeyCode.E)){
            if(!isPulled){
                pullLever();
            }
        }
    }

    void OnTriggerEnter(Collider other){
       if(other.CompareTag("Player")){
            player = other.transform;
            prompt.enableText(true);
       }
    }

    void OnTriggerExit(){
        player = null;
        prompt.enableText(false);
    }


    
}

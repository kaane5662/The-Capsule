using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EntityTrigger: MonoBehaviour{
    
    private bool isActivated = false;
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player") && !isActivated){
            Debug.Log("Activate");
            isActivated = true;
            Entity.activate(other.transform);
        }
    }


}
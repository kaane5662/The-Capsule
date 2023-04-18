using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{

    private bool alreadyActivated;
    private Transform player;
    private bool isTriggered;
    // Start is called before the first frame update
    void Start()
    {
        alreadyActivated = false;
    }

    void OnTriggerEnter(Collider other){
        Debug.Log("Entering");
        if(other.CompareTag("Player") && !alreadyActivated){
            alreadyActivated = true;
            Enemy.attack(other.transform);
        }
    }

    // Update is called once per frame
    
}

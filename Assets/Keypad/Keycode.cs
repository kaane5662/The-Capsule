using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycode : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;
    private int number;
    void Start()
    {
        
    }

    public void setNumber(int num){
        number = num;
    }

    private void pickUpKey(){

    }

    // Update is called once per frame
    void Update()
    {
        if(player != null){
            if(Input.GetKeyDown(KeyCode.E)){
                pickUpKey();
            }
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            player = other.transform;
        }
    }
}

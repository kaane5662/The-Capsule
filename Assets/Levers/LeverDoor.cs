using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverDoor : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform DoorObject;
    public Transform LeverObject;
    public Transform FloatingTextObject;
    public string interactText = "Pull Lever[E]";
    private FloatingText floatingText;
    private Transform player;


    private bool isActive;
    private bool isOpen;
    void Start()
    {
       isActive = false; 
       isOpen = false;
       player = null;
       floatingText = FloatingTextObject.GetComponent<FloatingText>();
       floatingText.updateParent();
       floatingText.updateText(interactText);
       floatingText.enableText(false);
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            floatingText.enableText(true);
            isActive = true;
            player = other.transform;
        }
    }

    void OnTriggerExit(){
        player = null;
        isActive = false;
        floatingText.enableText(false);
    }

    private void openDoor(){
        if(isOpen){return;}
        isOpen = true;
        LeverObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        DoorObject.gameObject.SetActive(false);
        floatingText.updateText("Lever pulled");
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive && player != null){
            if(Input.GetKeyDown(KeyCode.E)){
                openDoor();
            }
        }
    }
}

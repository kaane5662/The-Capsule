using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandeler : MonoBehaviour
{   

    // Start is called before the first frame update
    public Transform FloatingTextObject;
    private FloatingText floatingText;
    public Transform door;
    private bool isActive;
    private Transform player;
    
    private Queue<string> keys;
    void Start()
    {
        isActive= false;
        player = null;
        keys = new Queue<string>();
        keys.Enqueue("a"); keys.Enqueue("b"); keys.Enqueue("c"); keys.Enqueue("d");
        floatingText = FloatingTextObject.GetComponent<FloatingText>();
        Debug.Log(floatingText);
        floatingText.updateParent();
        floatingText.updateText("Insert Key[E]");
    }

    private void allKeysPlaced(){
        Debug.Log("Door opened");
        door.gameObject.SetActive(false);
    }

    private void checkKey(){
        Debug.Log("Checking key");
        Item isItem = player.GetComponentInChildren<Item>();
        if(isItem && isItem.getData().itemName.Equals("Key")){
            isItem.gameObject.SetActive(false);
            Destroy(isItem.gameObject);
            keys.Dequeue();
            Debug.Log("Keys remaining: "+keys.Count);
            if(keys.Count <= 0){
                allKeysPlaced();
            }
        }
    }
    
    // Update is called once per frame
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            Debug.Log("Enter");
            isActive = true;
            player = other.transform;
            floatingText.enableText(true);
        }
    }

    void OnTriggerExit(){
        Debug.Log("Leave");
        isActive = false;
        player = null;
        floatingText.enableText(false);
    }

    private void Update(){
        if(isActive && player != null){
            if(Input.GetKeyDown(KeyCode.E)){
                Debug.Log("pressed e");
                checkKey();
            }
        }
    }


}

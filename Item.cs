using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Item : MonoBehaviour
{   
    
    
    
    public ItemData itemData;
    public Vector3 promptOffset;
    public bool isStackable;
    private Transform player;
    private bool pickedUp = false;
    public void pickUp(Transform player){
        Debug.Log("Interacting");
        Debug.Log(player);
        this.player = player;
        player.GetComponent<HotbarManager>().addItem(gameObject, itemData, isStackable);
        pickedUp = true;
        GameObject.FindObjectOfType<FloatingText>().updatePrompt("Pick Up \n[E]", GameObject.Find("Loc").transform, promptOffset, true);
    }

    public void setTextPromptActive(bool state){
        if(pickedUp){return;}
        GameObject.FindObjectOfType<FloatingText>().updatePrompt("Pick Up \n[E]", transform, promptOffset, state);
    }





}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baracade : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    private bool isBroken;
    public Vector3 promptOffset;
    private Transform player;
    void Start()
    {
        gameObject.SetActive(true);
        isBroken = false;
    }

    // Update is called once per frame
    public void setTextPromptActive(bool state){
        GameObject.FindObjectOfType<FloatingText>().updatePrompt("Destroy [E]", transform, promptOffset, state);
    }

    private void checkTool(){
        Item isItem = player.GetComponentInChildren<Item>();
        if(isItem && isItem.itemData.type.Equals(ItemData.ItemType.Destroy)){
            gameObject.SetActive(false);
            isBroken = true;
            player.GetComponent<HotbarManager>().useItem();
        }
    }
    public void interact(Transform player){
        if(isBroken){return;}
        this.player = player;
        checkTool();
    }
}

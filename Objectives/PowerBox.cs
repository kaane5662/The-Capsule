using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBox : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update

    public Transform batteryPrefab;
    public Transform[] locations;
    public Transform[] lights;
    public Vector3 promptOffset;
    public string[] activateLines;
    public float completionDialogueDuration;
    public float timePerLine;
    private Queue<Transform> lightsQueue;
    private int requiredBatteries;
    private Transform player;
    private DialogueManager dialogue;

    private bool allBatteriesInserted;

    private void Start()
    {
        dialogue = GameObject.FindObjectOfType<DialogueManager>();  
        requiredBatteries = locations.Length;
        for(int i = 0; i < locations.Length; i++){
            Instantiate(batteryPrefab, locations[i].position, Quaternion.identity);
        }
        if(lights == null){return;}
        lightsQueue = new Queue<Transform>();
        for(int i =0; i < lights.Length; i++){
            lightsQueue.Enqueue(lights[i]);
        }
        allBatteriesInserted = false;
        


    }

    private IEnumerator updateDialogue(){
        dialogue.gameObject.SetActive(true);
        dialogue.setDisplay(activateLines, timePerLine);
        player.GetComponent<PlayerController>().enabled = false;
        yield return new WaitForSeconds(completionDialogueDuration);
        player.GetComponent<PlayerController>().enabled = true;
    }

    private void insertBattery(){
        Item isItem = player.GetComponentInChildren<Item>();
        if(isItem && isItem.itemData.type.Equals(ItemData.ItemType.Battery)){
            player.GetComponent<HotbarManager>().useItem();
            requiredBatteries--;
            lightsQueue.Dequeue().GetComponent<Renderer>().material.color = Color.green;
        }
        if(requiredBatteries <= 0){
            //activate entity
            Debug.Log("All batteries inserted");
            GameObject.FindObjectOfType<ExitDoor>().setAllBatteries(true);
            Debug.Log("Activating levers and enemy");
            Entity.changeActivate(true, player);
            Lever.changeActivate(true);
            StartCoroutine(updateDialogue());
            allBatteriesInserted = true;
            // Entity.changeActivate(true);
        }
    }

    public void setTextPromptActive(bool state){
        GameObject.FindObjectOfType<FloatingText>().updatePrompt("Insert Battery [E]", transform, promptOffset, state);
    }
    public void interact(Transform player){
        Debug.Log("Interacting");
        //testing
        if(player == null){return;}
        //test
        // Lever.changeActivate(true);
        // Entity.changeActivate(true, player);
        this.player = player;
        if(allBatteriesInserted){return;}
        insertBattery();
    }
}

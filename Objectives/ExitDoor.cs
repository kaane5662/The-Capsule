using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    public Transform[] signals;
    private Queue<Transform> signalSwitches;
    public int leversRequired;
    public Vector3 promptOffset;
    private Transform player;
    private bool allBatteriesActivated;
    private GameObject winSplash;

    void Start()
    {   
        if(signals == null){return;}
        leversRequired = signals.Length;
        signalSwitches = new Queue<Transform>();
        for(int i = 0; i < signals.Length; i++){
            signalSwitches.Enqueue(signals[i]);
        }
        winSplash = GameObject.FindGameObjectWithTag("WinSplash");
        winSplash.SetActive(false);
    }

    public void setAllBatteries(bool state){
        allBatteriesActivated = true;
        for(int i = 0; i < signals.Length; i++){
            signals[i].GetComponent<Renderer>().material.color = Color.yellow;
        }
        Debug.Log("Batteries activated");
    }
    public void changeLevers(){
        leversRequired -= 1;
        if(leversRequired <= 0){Debug.Log("All levers pulled");}
        if(signalSwitches != null)
            signalSwitches.Dequeue().GetComponent<Renderer>().material.color = Color.green;
    }



    // Update is called once per frame
    public void interact(Transform player){
        this.player = player;
        //AI Test
        if(leversRequired <= 0 && allBatteriesActivated){
            //win
            player.GetComponent<PlayerController>().enabled = false;
            winSplash.SetActive(true);
            Entity.changeActivate(false, player);
        }else{

        }
    }

    public void setTextPromptActive(bool state){
        GameObject.FindObjectOfType<FloatingText>().updatePrompt("Open [E]", transform, promptOffset, state);
    }
}

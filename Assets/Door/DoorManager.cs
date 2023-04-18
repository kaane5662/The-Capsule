using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorManager : MonoBehaviour
{
    // Start is called before the first frame update

    Queue<string> Objectives = new Queue<string>();

    // public delegate void updateObjectiveEvent(string word);
    // public static event updateObjectiveEvent updateObjective;

    private string currentState;
    private bool isOpen = false;

    
    void Start()
    {
        DoorEventManager.current.onLeverPulled += updateDoorObjective;
        for(int i = 0; i < 4; i++){
            Objectives.Enqueue("Find the lever "+"x"+(5-i));
        }
        
        Objectives.Enqueue("Open the door");
        ObjectiveHandler.updateObjective(Objectives.Peek());


        
        
    }
    
    private void doorOpened(){
        DoorEventManager.current.onLeverPulled -= updateDoorObjective;
    }

    private void openDoor(){
        // if(isOpen){
        //     // Destroy(gameObject, 3);
        // }else{

        // }
        
    }
    private void updateDoorObjective(){
        Debug.Log("Updated door");
        Objectives.Dequeue();
        if(Objectives.Count <= 0){
            isOpen = true;
        }
        Debug.Log("Levers: "+Objectives.Count);
        ObjectiveHandler.updateObjective(Objectives.Peek());
        
    }

    // Update is called once per frame
    
}

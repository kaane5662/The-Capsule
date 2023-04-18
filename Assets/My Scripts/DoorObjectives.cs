using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorObjectives
{
    // Start is called before the first frame update
    public static Queue<string> Objectives = new Queue<string>();
    public static UnityEvent someEvent;
    

    int levers = 5;
    int codes = 4;
    void Start()
    {   
        for(int i = 0; i < levers; i++){
            Objectives.Enqueue("Find the levers"+" x"+(levers-i));
        }
        Objectives.Enqueue("Get to the door");
        for(int i = 0; i < codes; i++){
            Objectives.Enqueue("Find the codes" + " x"+(codes-i));
        }
        
    }
    public static void finishObjective(){

    }

    public static string didObjective(){
        Objectives.Dequeue();
        if(Objectives.Count <= 0){
            finishObjective();
        }
        return Objectives.Peek();
    }
    // Update is called once per frame
}

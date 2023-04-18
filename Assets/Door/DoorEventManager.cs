using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DoorEventManager: MonoBehaviour{
    public static DoorEventManager current;
    void Awake(){
        current  = this;
    }
    public event Action onLeverPulled;
    public void pullLever(){
        Debug.Log("Pulled lever");
        onLeverPulled();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectiveEventManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static ObjectiveEventManager current;
    void Awake()
    {
        current = this;
    }
    // public event Action<string> onUpdateObjective;

    // public void updateObjective(string text){
    //     onUpdateObjective?.Invoke(text);
    // }

    // Update is called once per frame
}

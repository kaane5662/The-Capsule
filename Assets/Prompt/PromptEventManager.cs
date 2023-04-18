using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PromptEventManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static PromptEventManager current;
    void Awake()
    {
        current = this;
    }

    // Update is called once per frame
    public event Action<string> onUpdatePrompt;
    public void updatePrompt(string newText){
        onUpdatePrompt?.Invoke(newText);
    }
    public event Action onDisablePrompt;
    public void disablePrompt(){
        onDisablePrompt?.Invoke();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;

public class UpdateInteractionPrompt : MonoBehaviour
{
    private GameObject Prompt;
 

    // public static UpdatePromptEvent updatePromptEvent = new UpdatePromptEvent();
    // Start is called before the first frame update
    void Start()
    {
        Prompt = gameObject;
        PromptEventManager.current.onUpdatePrompt += updatePrompt;
        PromptEventManager.current.onDisablePrompt += disablePrompt;
    }

    // Update is called once per frame

    public void disablePrompt(){
        Prompt.SetActive(false);
    }
    public void updatePrompt(string text){
        // Debug.Log("Called update prompt");
        Prompt.SetActive(true);
        Prompt.GetComponent<TextMeshProUGUI>().text = text;
    }

}

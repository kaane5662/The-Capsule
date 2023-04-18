using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DialogueManager : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshProUGUI dialogueText;
    void Start()
    {   
        dialogueText = transform.GetComponent<TextMeshProUGUI>();;
        DialogueEventManager.onUpdateText += onUpdateText;
        DialogueEventManager.onDisableText += onDisableText;
    }


    // Update is called once per frame
    private IEnumerator updateText(string text)
    {   
        Debug.Log("How many times is this running");
        dialogueText.text = "";
        Debug.Log(text);
        foreach(char letter in text.ToCharArray()){
            yield return new WaitForSeconds(.1f);
            dialogueText.text += letter;
        }
    }

    private IEnumerator disableText(){
        yield return new WaitForSeconds(3);
        dialogueText.text = "";
    }

    private void onUpdateText(string text){
        Debug.Log("Event updated for thing");
        StopAllCoroutines();
        StartCoroutine(updateText(text));
    }
    private void onDisableText(){
        StopAllCoroutines();
        StartCoroutine(disableText());
    }
}

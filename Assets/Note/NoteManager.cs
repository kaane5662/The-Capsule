using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class NoteManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform note;
    private TextMeshProUGUI heading;
    private TextMeshProUGUI description;
    private TextMeshProUGUI closing;
    private ObjectiveHandler objectiveHandler;

    private void Start(){
        heading = note.Find("Header").GetComponent<TextMeshProUGUI>();
        description = note.Find("Desc").GetComponent<TextMeshProUGUI>();
        closing = note.Find("Closing").GetComponent<TextMeshProUGUI>();
    }
    
    public void activatePrompt(string heading, string description, string closing, string objectiveText, bool hasObjective){
        Debug.Log("I have arrived here at the note manager");
        this.heading.text = heading;
        this.description.text = description;
        this.closing.text = closing;
        note.gameObject.SetActive(true);
        if(hasObjective){
            ObjectiveHandler.updateObjective(objectiveText);
        }
    }

    public void disablePrompt(){
        note.gameObject.SetActive(false);
    }
}

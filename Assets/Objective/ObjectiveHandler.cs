using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class ObjectiveHandler : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshProUGUI ObjectiveText;
    public static event Action<String> onUpdateObjective;
    public static void updateObjective(String newText){
        onUpdateObjective?.Invoke(newText);
    }
    void Start()
    {
        ObjectiveText = GameObject.Find("Task").GetComponent<TextMeshProUGUI>();
        onUpdateObjective += updateObjectiveText;
        updateObjectiveText("Find the key");
    }

    // Update is called once per frame
    void updateObjectiveText(string text){
        Debug.Log("This works?");
        ObjectiveText.text = text;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshProUGUI dialogueText;
    void Start()
    {
        dialogueText = transform.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public IEnumerator displayText(string[] lines, float timePerLine){
        gameObject.SetActive(true);
        foreach(string line in lines){
            Debug.Log(line);
            dialogueText.text = line;
            yield return new WaitForSeconds(timePerLine * line.Length);
        }
        gameObject.SetActive(false);
    }

    public void setDisplay(string[] lines, float timePerLine){
        StartCoroutine(displayText(lines, timePerLine));
    }
}

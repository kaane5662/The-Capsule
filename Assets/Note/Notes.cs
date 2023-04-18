using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    // Start is called before the first frame update
    public NoteData noteData;
    private bool isViewing = false;
    private bool canView = true;
    private bool canLeave = true;
    private NoteManager noteManager;
    private GameObject player;
    private FloatingText prompt;
    private void Start(){
        // promptCopy = Instantiate(promptReference, transform.position + new Vector3(0,2,0), Quaternion.identity);
        prompt = transform.parent.GetComponentInChildren<FloatingText>();
        prompt.updateParent();
        disablePrompt();
    }

    // Update is called once per frame
    private void disablePrompt(){
        prompt.enableText(false);
    }
    private IEnumerator readNote(){
        //by default the notes have an objective
        disablePrompt();
        isViewing = true;
        canLeave = false;
        noteManager.activatePrompt(noteData.header, noteData.description, noteData.closing, noteData.objectiveUpdate, true);
        yield return new WaitForSeconds(1.5f);
        canLeave = true;

    }
    private IEnumerator closeNote(){
        isViewing = false;
        canView = false;
        noteManager.disablePrompt();
        prompt.enableText(true);
        yield return new WaitForSeconds(1.5f);
        canView = true;
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            player = other.gameObject;
            noteManager = player.GetComponent<NoteManager>();
            prompt.enableText(true);
        }
    }

    private void Update(){
        if(player == null || noteManager == null){return;}
        if(Input.GetKeyDown(KeyCode.E)){
            if(canView && !isViewing){
                StartCoroutine(readNote());
            }else if(isViewing && canLeave){
                StartCoroutine(closeNote());
            } 
        }
    }

    private void OnTriggerExit(){
        disablePrompt();
        player = null;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    // Start is called before the first frame update
    private bool alreadyActivated = false;
    public string[] starterTexts;
    private Transform player;


    private IEnumerator activeStartScene(){
        alreadyActivated = true;
        player.GetComponent<PlayerController>().enabled = false;
        player.localRotation = Quaternion.identity;
        for(int i = 0; i < starterTexts.Length; i++){
            DialogueEventManager.updateText(starterTexts[i]);
            yield return new WaitForSeconds(5f);
        }
        DialogueEventManager.disableText();
        player.GetComponent<PlayerController>().enabled = true;
    }

    void OnTriggerEnter(Collider other){
        Debug.Log("Entered start");
        if(other.CompareTag("Player")){
            Debug.Log("Is player");
            player = other.transform;
            if(!alreadyActivated){
                //temporary disable
                // StartCoroutine(activeStartScene());
            }
        }
    }
    // Update is called once per frame
    
}

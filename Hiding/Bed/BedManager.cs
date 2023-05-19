// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class BedManager : MonoBehaviour
// {
//     // Start is called before the first frame update
//     public Transform player;
//     public Transform enter;
//     public Transform spot;
//     public float hidingCoolDown = 3;

//     private bool isHiding;
//     private bool canHide = true;
//     private bool canLeave = true;

//     private Vector3 originalScale;

//     private string status = "Hide in Bed[E]";
    
//     private IEnumerator hide(){
//         isHiding = true;
//         canLeave = false;
//         EntityEventHandler.setAgentCanAttack(false);
//         player.GetComponent<PlayerController>().enabled = false;
//         player.position = enter.position;
//         player.GetComponentInChildren<Camera>().transform.localRotation = Quaternion.identity;
//         Vector3 spotDir = -(player.position-spot.position);
//         player.rotation = Quaternion.LookRotation(spotDir, Vector3.up);
//         //scale down player;
//         originalScale = player.localScale;
//         Vector3 targetScale = new Vector3(originalScale.x, originalScale.y/5, originalScale.z);
//         for(int t = 0; t < 200; t++){
//             yield return new WaitForEndOfFrame();
//             player.localScale = Vector3.Lerp(player.localScale, targetScale, (float)t/200);
//         }
//         yield return new WaitForSeconds(.5f);
//         //move player to spot;
//         for(int t = 0; t < 200; t++){
//             yield return new WaitForEndOfFrame();
//             player.position = Vector3.Lerp(player.position, spot.position, (float)t/200);
//         }
//         //rotate player
//         Vector3 enterDir = -(player.position-enter.position);
//         for(int t = 0; t < 100; t++){
//             yield return new WaitForEndOfFrame();
//             player.rotation = Quaternion.Lerp(player.rotation, Quaternion.LookRotation(enterDir, Vector3.up), (float)t/100);
//         }
//         status = "Leave Bed[E]";
//         canLeave = true;
//     }

//     private IEnumerator leave(){
//         isHiding = false;
//         canHide = false;
//         Vector3 enterDir = -(player.position-enter.position);
//         player.rotation = Quaternion.LookRotation(enterDir, Vector3.up);
//         //move player to enter
//         for(int t = 0; t < 200; t++){
//             yield return new WaitForEndOfFrame();
//             player.position = Vector3.Lerp(player.position, enter.position, (float)t/200);
//         }
//         yield return new WaitForSeconds(.5f);
//         //scale up player
//         for(int t = 0; t < 200; t++){
//             yield return new WaitForEndOfFrame();
//             player.localScale = Vector3.Lerp(player.localScale, originalScale, (float)t/200);
//         }
//         // yield return new WaitForSeconds(.5f);
//         player.GetComponent<PlayerController>().enabled = true;
//         EntityEventHandler.setAgentCanAttack(true);
//         yield return new WaitForSeconds(hidingCoolDown);
//         status = "Hide in Bed[E]";
//         canHide = true;
//     }

//     private void disablePrompt(){
//         PromptEventManager.current.disablePrompt();
//     }

//     // Update is called once per frame
//     private void displayPrompt(){
//         if(canHide && canLeave){
//             PromptEventManager.current.updatePrompt(status);
//         }else{
//             disablePrompt();
//         }
//         if(Input.GetKey(KeyCode.E)){
//             if(!isHiding && canHide){
//                 StartCoroutine(hide());
//             }else if(isHiding && canLeave){
//                 StartCoroutine(leave());
//             }
//         }
//     }

//     void OnTriggerStay(Collider other){
//         displayPrompt();
//     }

//     void OnTriggerExit(){
//         disablePrompt();
//     }
// }

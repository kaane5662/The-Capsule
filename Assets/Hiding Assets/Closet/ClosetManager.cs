// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System;

// public class ClosetManager: MonoBehaviour
// {   
//     public Transform player;

//     public Transform hidingPosition;
//     public Transform leavingPosition;
//     private bool isInside = false;
//     private bool canLeave = true;
//     private bool canHide = true;
//     private string interactionText = "Hide[E]";
   

//     private IEnumerator hide(){
//         canLeave = false;
//         isInside = true;
//         player.GetComponent<PlayerController>().enabled = false;
//         EntityEventHandler.setAgentCanAttack(false);
//         player.transform.position = leavingPosition.position;
//         player.GetComponentInChildren<Camera>().transform.localRotation = Quaternion.identity;
//         Vector3 enterDir = -(player.transform.position - hidingPosition.position);
//         player.transform.rotation = Quaternion.LookRotation(enterDir, Vector3.up);
//         yield return new WaitForSeconds(.5f);
//         for(int t=0; t< 200; t++){
//             yield return new WaitForEndOfFrame();
//             player.transform.position = Vector3.Lerp(player.transform.position, hidingPosition.position,  (float)t/200  );
//         }
//         Vector3 rotateEnterDir = -(player.transform.position - leavingPosition.position);
//         for(int t = 0; t < 100; t++){
//             yield return new WaitForEndOfFrame();
//             player.transform.rotation = Quaternion.Lerp(player.transform.rotation, Quaternion.LookRotation(rotateEnterDir, Vector3.up), (float)t/100);
//         }
//         interactionText = "Leave[E]";
//         canLeave = true;
//     }

//     private IEnumerator leave(){
//         canHide = false;
//         isInside = false;
//         Vector3 leaveDir = -(player.transform.position - leavingPosition.position);
//         player.transform.rotation = Quaternion.LookRotation(leaveDir, Vector3.up);
//         for(int t = 0; t < 200; t++){
//             yield return new WaitForEndOfFrame();
//             player.transform.position = Vector3.Lerp(player.position, leavingPosition.position, (float)t/200);
//         }
//         EntityEventHandler.setAgentCanAttack(true);
//         player.GetComponent<PlayerController>().enabled = true;
//         interactionText = "Hide[E]";
//         yield return new WaitForSeconds(3);
//         canHide = true;
//     }

//     private void disablePrompt(){
//         PromptEventManager.current.disablePrompt();
//     }
//     private void displayPrompt(){
//         if(canLeave && canHide){
//             PromptEventManager.current.updatePrompt(interactionText);
//         }else{
//             disablePrompt();
//         }
//         if(Input.GetKey(KeyCode.E)){
//             if(!isInside && canHide){
//                 StartCoroutine(hide());
//             }else if(canLeave && isInside){
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

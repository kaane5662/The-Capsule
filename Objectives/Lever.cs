using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    public static bool isActivated;
    public Vector3 promptOffset;
    private bool isPulled;
    private Transform handle;

    private void Start(){
        isPulled = false;
        isActivated = false;
        handle = transform.parent.Find("Lever").transform;
    }
    public static void changeActivate(bool state){
        isActivated = state;
    }
    
    public void setTextPromptActive(bool state){
        GameObject.FindObjectOfType<FloatingText>().updatePrompt("Pull [E]", transform, promptOffset, state);
    }
    public void interact(Transform player){
        if(isActivated && !isPulled){
            //lever stuff
            isPulled = true;
            Debug.Log("Doing lever");
            handle.RotateAround(transform.position, Vector3.right, -75f);
            GameObject.FindObjectOfType<ExitDoor>().changeLevers();
        }
    }
}

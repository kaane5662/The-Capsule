using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideable : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update

    public Transform hiding;
    public Transform exit;
    public Vector3 promptOffset;

    private Transform player;
    private bool isHiding;

    private void hide(){
        player.GetComponent<PlayerController>().enabled = false;
        player.position = hiding.position;
        Vector3 lookDir = (exit.position-hiding.position);
        player.rotation = Quaternion.LookRotation(lookDir,Vector3.up);
        isHiding = true;
        Entity.changeCanAttack(false);
    }

    private void leave(){
        player.position = exit.position;
        player.GetComponent<PlayerController>().enabled = true;
        isHiding = false;
        Entity.changeCanAttack(true);
    }

    public void setTextPromptActive(bool state){
        GameObject.FindObjectOfType<FloatingText>().updatePrompt("Hide [E]", transform, promptOffset, state);
    }

    public void interact(Transform player){
        this.player = player;
        if(player == null){return;}
        if(!isHiding){
            hide();
        }else{
            leave();
        }
    }
}

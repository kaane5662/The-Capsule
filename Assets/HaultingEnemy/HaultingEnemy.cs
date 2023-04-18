using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HaultingEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isAttacking;
    private bool isActive;
    private int attackRepitions;
    public float stareTimeBeforeDeathFrames = 180;

    public int attackRepeats = 10;

    public Transform[] points;
    private Transform currentPositionTransform;



    private bool playerInFrontOfEnemy;
    private bool staringActive = false;
    private Transform player;

    public static event Action<Transform> onAttack;

    void Start()
    {
        onAttack += attack;
        player = null;
    }

    public static void setAttack(Transform player){
        Debug.Log("Yooo");
        onAttack?.Invoke(player);
    }
    public void attack(Transform player){
        this.player = player;
        isActive = true;
        StartCoroutine(checkPlayerFacing());
        StartCoroutine(trackAttack());
    }

    private void playerFacingEnemy(){
        Vector3 dir = (transform.position - player.position).normalized;
        // Debug.Log(Vector3.Dot(player.forward, dir) );
        if(Vector3.Dot(player.forward, dir) < 0){
            playerInFrontOfEnemy = false;
        }else{
            playerInFrontOfEnemy = true;
        }
    }

    private IEnumerator checkPlayerFacing(){
        while(isActive){
            playerFacingEnemy();
            if(!staringActive && playerInFrontOfEnemy){
                StartCoroutine(staring());
            }
            yield return new WaitForFixedUpdate();
        }
    }
    private void changePosition(){
        if(currentPositionTransform.Equals(points[0])){
            currentPositionTransform = points[1];
        }else{
            currentPositionTransform = points[0];
        }
        transform.position = currentPositionTransform.position;
    }

    private IEnumerator trackAttack(){
        currentPositionTransform = points[0];
        transform.position = currentPositionTransform.position;
        for(int t = 0; t < attackRepeats; t++){
            if(!playerInFrontOfEnemy){
                Debug.Log("Not staring");
                changePosition();
            }
            yield return new WaitForSeconds(1.5f);
        }
        gameObject.SetActive(false);
        isActive = false;
        StopAllCoroutines();
        Debug.Log("Round over");
    }
    private IEnumerator staring(){
        staringActive = true;
        for(int t = 0; t < stareTimeBeforeDeathFrames; t++){
            if(!playerInFrontOfEnemy){
                staringActive = false;
                yield break;
            }
            Debug.Log("Staring");
            yield return new WaitForFixedUpdate();
        }
        Debug.Log("Dead");
        isActive = false;
        StopAllCoroutines();
    }

}

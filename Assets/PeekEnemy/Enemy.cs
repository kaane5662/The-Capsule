using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    private bool isAttacking;
    private bool isRunning;
    public float coolDownTimeBetweenTransitions = .25f;
    public float coolDownTimeBetweenAttacks = 5f;
    public int attackDurationFrames = 600;
    public int attackRepitions = 5;
    public Transform[] points;
    private Transform player;
    
    public static event Action<Transform> onAttack;

    // Start is called before the first frame update
    void Start()
    {
        onAttack += setAttack;
        player = null;
    }

    public static void attack(Transform player){
        onAttack.Invoke(player);
    }
    public void setAttack(Transform player){
        this.player = player;
        StartCoroutine(trackAttack());
        Debug.Log(player);
    }

    private IEnumerator trackAttack(){
        int repitions = 0;
        Vector3 dest = player.position;
        isRunning = true;
        StartCoroutine(startAttack());
        while(repitions < attackRepitions){
            isAttacking = false;
            yield return new WaitForSeconds(coolDownTimeBetweenAttacks);
            isAttacking = true;
            Vector3 initalPos = transform.position;
            for(int t = 0; t < attackDurationFrames; t++){
                Debug.Log("Attacking");
                Debug.Log(t);
                transform.position = Vector3.Lerp(initalPos, dest, (float) t/attackDurationFrames);
                yield return new WaitForFixedUpdate();
            }
            repitions++;
        }
        isRunning = false;
        player = null;
    }

    private IEnumerator startAttack(){
        Debug.Log("Starting attack");
        while(isRunning){
            if(!isAttacking && player != null){
                Debug.Log("Positioning enemy");
                Transform closestPoint = calculateClosestPoint();
                if(closestPoint != null){
                    transform.position = closestPoint.position;
                    transform.rotation = Quaternion.LookRotation(player.position-transform.position, Vector3.up);
                }
            }
            yield return new WaitForSeconds(coolDownTimeBetweenTransitions);
        }
    }

    private Transform calculateClosestPoint(){
        RaycastHit hit;
        //get the closest point to the forward direction of the player
        if(Physics.Raycast(player.transform.position, player.forward, out hit, 999f)){
            int closestIndex = 0;
            for(int i =0; i < points.Length; i++){
                if(Vector3.Distance(hit.transform.position, points[i].position) < Vector3.Distance(hit.transform.position, points[closestIndex].position)){
                    closestIndex = i;
                }
            }
            Debug.Log(points[closestIndex]);
            return points[closestIndex];
        }
        return null;
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            Debug.Log("Player hit");
        }
    }
}

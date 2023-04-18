using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class Entity : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent agent;
    private Transform player;

    public Transform[] waypoints;
    public float maxDistance = 30f;
    public float waypointCooldown = 3f;
    public float waypointWalkSpeed;
    public float attackSpeed;
    private Transform recentWaypoint;

    private bool isActive = false;
    private bool canAttack = true;

    private bool isAttacking = false;
    private bool canProceedNextWaypoint = true;
    
    private static event Action<Transform> onActivate;
    
    void Start(){
        recentWaypoint = null;
        player = null;
        onActivate += setActive;
    }

    private void setActive(Transform player){
        this.player = player;
        isActive = true;
        StartCoroutine(trackAttack());
    }
    public static void activate(Transform player){
        onActivate?.Invoke(player);
    }
    private void updateCanAttack(bool canAttack){
        Debug.Log("Entity attach has been updated");
        this.canAttack = canAttack;
    }

    private bool isPlayerSeen(){
        RaycastHit hit;
        Vector3 dir = (player.position - transform.position).normalized;
        if(Physics.Raycast(transform.position, dir, out hit, maxDistance)){
            if(hit.transform == player){
                return true;
            }
        }
        return false;
    }

    private bool isEntityFacingPlayer(){
        Vector3 dir = (player.position-transform.position).normalized;
        float facing = Vector3.Dot(transform.forward, dir);
        Debug.Log(facing);
        if(facing > 0){
            return true;
        }
        return false;
    }


    private IEnumerator proceedNextWaypoint(){
        //choose next waypoint, but make sure it isn't recent;
        // Debug.Log("Setting next waypoint");
        agent.speed = waypointWalkSpeed;
        canProceedNextWaypoint = false;
        Transform nextWaypoint = waypoints[UnityEngine.Random.Range(0, waypoints.Length)];
        while(nextWaypoint.Equals(recentWaypoint)){
            nextWaypoint = waypoints[UnityEngine.Random.Range(0, waypoints.Length)];
        }
        recentWaypoint = nextWaypoint;
        agent.SetDestination(nextWaypoint.position);
        yield return new WaitUntil(() => (agent.remainingDistance == 0 || isAttacking) );
        // Debug.Log("Cooling down");
        yield return new WaitForSeconds(waypointCooldown);
        // Debug.Log("Cooling complete");
        canProceedNextWaypoint = true;
    }

    private IEnumerator trackAttack(){
        while(isActive){
            if(isPlayerSeen() && isEntityFacingPlayer()){
                Debug.Log("See and is facing");
                agent.speed = attackSpeed;
                isAttacking = true;
                agent.SetDestination(player.position);
            }else{
                // Debug.Log("Is not facing or seeing");
                isAttacking = false;
                if(canProceedNextWaypoint) {StartCoroutine(proceedNextWaypoint());}
            }
            yield return new WaitForEndOfFrame();
        }
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other){
        
        if(other.CompareTag("Player")){
            Debug.Log("Game over");
            isActive = false;
            StopAllCoroutines();
        }
    }

    
}

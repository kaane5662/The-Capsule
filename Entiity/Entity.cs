using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class Entity : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent agent;
    private static Transform player;
    public Transform[] waypoints;
    public float maxDistance = 30f;
    public float waypointCooldown = 3f;
    public float waypointWalkSpeed;
    public float attackSpeed;
    private Transform recentWaypoint;

    private static bool isActive = false;
    private static bool canAttack = true;

    private bool spawned;

    private bool isAttacking = false;
    private bool canProceedNextWaypoint = true;

    private GameObject deathSplash;
    
    private void Start(){
        deathSplash = GameObject.FindGameObjectWithTag("DeathSplash");
        deathSplash.SetActive(false);
    }
    public static void changeActivate(bool state, Transform _player){
        isActive = state;
        player = _player;
    }

    public static void changeCanAttack(bool state){
        canAttack = state;
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
        while(recentWaypoint != null && nextWaypoint.Equals(recentWaypoint)){
            nextWaypoint = waypoints[UnityEngine.Random.Range(0, waypoints.Length)];
        }
        recentWaypoint = nextWaypoint;
        agent.SetDestination(nextWaypoint.position);
        yield return new WaitUntil(() => (agent.remainingDistance == 0 || isAttacking) );
        yield return new WaitForSeconds(waypointCooldown);
        canProceedNextWaypoint = true;
    }

    private void Update(){
        if(isActive){
            if(!spawned){transform.position = waypoints[UnityEngine.Random.Range(0, waypoints.Length)].position; spawned = true;}
            if(isPlayerSeen() && isEntityFacingPlayer() && canAttack){
                isAttacking = true;
                agent.speed = attackSpeed;
                agent.SetDestination(player.position);
            }else if(canProceedNextWaypoint){
                isAttacking = false;
                StartCoroutine(proceedNextWaypoint());
            }
        }
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other){
        if(!isActive){return;}
        
        Debug.Log("Sheesh: "+other.tag);
        if(other.CompareTag("Player")){
            //die
            Debug.Log("dead");
            isActive = false;
            deathSplash.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            player.GetComponent<PlayerController>().enabled = false;
        }
    }

    
}

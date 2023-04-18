using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaultingEnemyTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isActivated;
    void Start()
    {
        isActivated = false;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !isActivated){
            isActivated = true;
            HaultingEnemy.setAttack(other.transform);
        }
    }
}

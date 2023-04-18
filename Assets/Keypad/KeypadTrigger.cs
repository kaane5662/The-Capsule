using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isActive;
    public GameObject keyPrefab;
    public Transform[] keyPoints;

    void Start()
    {
        isActive = false;
    }

    private void spawnKeys(){
        for(int i =0; i < keyPoints.Length; i++){
            GameObject instancedKey = Instantiate(keyPrefab, keyPoints[i].position, Quaternion.identity);
            instancedKey.GetComponent<Keycode>().setNumber(Random.Range(0,9));
        }
    }
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !isActive){
            isActive = true;
            spawnKeys();
        }
    }
}

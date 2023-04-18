using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandManager : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isEquipped;
    private float shakeFrequency;
    private float shakeAmplitude;
    private Vector3 lastPosition;

    private GameObject obj;

    public void updateHand(float shakeFrequency, float shakeAmplitude, GameObject obj){
        //initialize
        this.shakeFrequency = shakeFrequency;
        this.shakeAmplitude = shakeAmplitude;
        this.obj = obj;
        //make item visible
        this.obj.transform.SetParent(transform);
        this.obj.SetActive(true);
        isEquipped = true;
        Debug.Log("Equipped item for hand!");
    }

    public GameObject removeHand(){
        obj.SetActive(false);
        GameObject tempObj = obj;
        isEquipped = false;
        return tempObj;
    }

    // Update is called once per frame
    void Update()
    {
        //hand animations
        if(isEquipped && obj != null && Vector3.Distance(lastPosition, transform.position) > 0){
            Vector3 offset = new Vector3(0,Mathf.Sin(shakeFrequency*Time.fixedTime)*shakeAmplitude,0);
            transform.localPosition = Vector3.Lerp(transform.localPosition, offset, .1f);
        }
        lastPosition = transform.position;
    }
}

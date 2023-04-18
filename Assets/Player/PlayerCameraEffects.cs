using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCameraEffects:MonoBehaviour{
    public Transform cam;
    public Transform player;

    public float cameraFrequency;
    public float cameraAmplitude;

    public CharacterController controller;

    private void updateCamera(){
        Vector3 horizontalVelocity = new Vector3(controller.velocity.x, 0, controller.velocity.z);
        // Debug.Log(horizontalVelocity.magnitude);
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0){
            // Debug.Log("Moving");
            Vector3 offset = new Vector3(0,Mathf.Sin(cameraFrequency*Time.fixedTime)*cameraAmplitude,0);
            // Debug.Log(offset);
            cam.localPosition = Vector3.Lerp(cam.localPosition, offset, .1f);
        }
    }

    void Update(){
        updateCamera();
    }


}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform player;
    public Transform cam;
    public float mouseSens;
    public float gravity = -9.81f;
    public float jumpHeight = 5f;
    public CharacterController controller;

    public Transform start;
    public float speed;

    public float sprintSpeed;
    public Transform groundCheck;
    public float groundDistance = .4f;
    public LayerMask groundMask;

    private float xRotation;
    private float yRotation;
    private Vector3 velocity;

    private bool isGrounded;

    private void Start(){
        transform.position = start.position;
    }
    
    private void updateCamera(){
        float mouseX = Input.GetAxisRaw("Mouse X")*Time.deltaTime*mouseSens;
        float mouseY = Input.GetAxisRaw("Mouse Y")*Time.deltaTime*mouseSens;
        xRotation -= mouseY;
        yRotation += mouseX;
        xRotation = Mathf.Clamp(xRotation,-90,90);
        transform.rotation = Quaternion.Euler(0f,yRotation, 0f);
        cam.rotation = Quaternion.Euler(xRotation,yRotation,0f);
        // cam.position = transform.position;
    }

    void updateMovement(){
        float movementSpeed = speed;
        isGrounded = Physics.Raycast(groundCheck.position,Vector3.down, groundDistance);
        float vertInput = Input.GetAxisRaw("Vertical");
        float horizInput = Input.GetAxisRaw("Horizontal");
        Vector3 direction = transform.forward * vertInput + transform.right*horizInput;
        if(isGrounded && Input.GetKey(KeyCode.LeftShift)){
            movementSpeed = sprintSpeed;
        }
        controller.Move(direction*movementSpeed*Time.deltaTime);
        if(isGrounded && velocity.y <= 0){
            // Debug.Log("Grounded");
            velocity.y = -2f;
        }
        if(isGrounded && Input.GetKey(KeyCode.Space)){
            velocity.y = Mathf.Sqrt(jumpHeight*-2f*gravity);
        }

        
        velocity.y += gravity*Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);

    }


    // Update is called once per frame
    void Update()
    {
        updateCamera();
        updateMovement();
    }
}

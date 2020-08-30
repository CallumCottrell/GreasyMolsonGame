using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;

    public Transform groundCheck;

    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    //public float jumpHeight = 3f;

    Vector3 velocity;

    bool isGrounded;

    public float jumpVelocity;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
 
    float distanceToGround;
    void Start(){
        distanceToGround = transform.position.y - groundCheck.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = IsGrounded();

        if (isGrounded && velocity.y <0)
        {
            velocity.y = -2f;
        } 
        float x = Input.GetAxis("Horizontal");
      
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetKey(KeyCode.LeftShift))
            speed = 24;
        else    
            speed = 12;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity = Vector3.up * jumpVelocity;
        }
 
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if(velocity.y < 0)
        {
        velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        else if (velocity.y > 0 && !Input.GetButton ("Jump")) {
            velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;

        }



                
    }

    bool IsGrounded(){

    return Physics.Raycast(groundCheck.position, -Vector3.up, .75f);
    
    }
 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class Sled : MonoBehaviour
{
   // public CharacterController sledController;

    public Rigidbody rb;
    public float speed = 12f;
    public float gravity = -9.81f;

    public float groundDistance = 0.4f;

    public Camera sledCamera;
    Vector3 move;
    Vector3 velocity;
    public float jumpVelocity;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
 
    private bool active = false;
     void Start(){
    
    }

    // Update is called once per frame
    void Update()
    {
        if (active){

        float x = Input.GetAxis("Horizontal");
      
        float z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;

        if (Input.GetKey(KeyCode.LeftShift))
            speed = 24;
        else    
            speed = 12;

        }
       
 
    }

 
    public void activateSled(GameObject player){
              
              active = true;
              player.GetComponentInChildren<Camera>().enabled = false;
              sledCamera.enabled = true;
              sledCamera.GetComponent<MouseLook>().enabled = true;

              //this.GetComponent<CharacterController>().enabled = true;
             // player.GetComponent<CharacterController>().enabled = false;
    }

    void FixedUpdate(){

        rb.MovePosition(rb.position + move * 12 * Time.fixedDeltaTime);
  
    }
}

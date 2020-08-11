using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Canvas canvas;
    public GameObject checkmark;

    public GameObject textGO;
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
 
    bool treeSeen = false;
    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y <0)
        {
            velocity.y = -2f;
        } 
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;


        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity = Vector3.up * jumpVelocity;
        };
 
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if(velocity.y < 0)
        {
        velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        else if (velocity.y > 0 && !Input.GetButton ("Jump")) {
            velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;

        }

        RaycastHit rayHit;
        Ray landingRay = new Ray(transform.position, Vector3.forward);
        
        if (!treeSeen && Physics.Raycast(landingRay, out rayHit, 5)){
            if (rayHit.collider.tag == "tree"){
            
            textGO = new GameObject("check");

            textGO.transform.SetParent(canvas.transform);
           
            textGO.transform.TransformVector(new Vector3(0,0,0));
            Text myText = textGO.AddComponent<Text>();
            Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
            myText.font = ArialFont;
            myText.text = "You made this by looking at a tree";


            UnityEngine.Debug.Log("Raycast worked");

            treeSeen = true;
            }   
           
        }
    }

    void Start(){
       
    }
    
}

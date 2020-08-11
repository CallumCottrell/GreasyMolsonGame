using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Canvas canvas;

    public Slider mapleBar;

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
 
    public int treeCheckDistance = 6;

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
        Ray landingRay = new Ray(transform.position, this.transform.forward);
        
        if (Physics.Raycast(landingRay, out rayHit, treeCheckDistance)){
            if (!treeSeen && rayHit.collider.tag == "tree"){
            
            //Going to create a text object to put in the canvas
            textGO = new GameObject("check");

            // Set the canvas as the parent
            textGO.transform.SetParent(canvas.transform);
           
            //I hate this. I dont know why i need to do this
            textGO.transform.Translate(new Vector3(706, 397, 0));

            Text myText = textGO.AddComponent<Text>();
            Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
            myText.font = ArialFont;
            myText.text = "Press E for Maple Syrup";


            UnityEngine.Debug.Log("Raycast worked");
            treeSeen = true;
            }      

        }
        else {
            if (textGO){
                Destroy(textGO);
                treeSeen = false;
            }
                         
        }

        if (treeSeen && Input.GetKeyDown(KeyCode.E)){
                UnityEngine.Debug.Log("You pressed E");
                //Fill the bucket
                mapleBar.value += 10;

            }
    }

    void Start(){
       
    }
    
}

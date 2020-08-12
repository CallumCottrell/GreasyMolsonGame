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


    //enemyDamage is how much syrup is taken from the tree
    public float enemyDamage = 10f;
    
    Vector3 velocity;

    bool isGrounded;

    public float jumpVelocity;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
 
    public int treeCheckDistance = 6;

    bool lookingAtTree = false;
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
        Ray rayFromPlayer = new Ray(transform.position, this.transform.forward);
        
        if (Physics.Raycast(rayFromPlayer, out rayHit, treeCheckDistance)){
            if (!lookingAtTree && rayHit.collider.tag == "tree"){

            createTextOnCursor("Press E for Maple Syrup");
    
            UnityEngine.Debug.Log("Raycast worked");
            lookingAtTree = true;
            }      

        }
        else {
            if (textGO){
                Destroy(textGO);
                lookingAtTree = false;
            }
                         
        }

        if (lookingAtTree && Input.GetKeyDown(KeyCode.E)){
                //UnityEngine.Debug.Log("You pressed E");

                    rayHit.transform.GetComponent<TreeHealth>().RemoveHealth(enemyDamage); 
                    
                }
                //Fill the bucket
                //mapleBar.value += 10;
    }

    void Start(){
       
    }
    
    void createTextOnCursor(string text){
         //Going to create a text object to put in the canvas
            textGO = new GameObject("check");

            // Set the canvas as the parent
            textGO.transform.SetParent(canvas.transform);
            textGO.transform.Translate(Screen.width/2, Screen.height/2, 0);

            Text myText = textGO.AddComponent<Text>();
            Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
            myText.font = ArialFont;
            myText.text = text;

    }
}

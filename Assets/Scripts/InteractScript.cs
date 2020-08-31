using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
    This script handles the player's interaction with the world through  
    raycast. 
*/
public class InteractScript : MonoBehaviour
{
    public Canvas mainCanvas;
    private GameObject mapleHealthGO;
    private GameObject textGO;
    private RaycastHit currentObject;

    public Camera cam;

    //How far away the looking raycast will go
    const int lookDistance = 4;

    bool lookingAtTree = false;
    bool lookingAtSled = false;

    //The interacting variable ensures that the ray wont continuously check tags
    bool interacting = false;

    // Fixed Update is easier on the engine for the raycast. Updates less frequently
    void FixedUpdate()
    {
        
        // Check for what the user is looking at by casting a ray forward from the user
        RaycastHit rayHit;
    
        Ray rayFromPlayer = new Ray(cam.transform.position, cam.transform.forward);
        
        //This tool draws a raycast from the player on the screen to see where it's going
        Debug.DrawRay(cam.transform.position, cam.transform.forward, Color.green);
        
    
        if (Physics.Raycast(rayFromPlayer, out rayHit, lookDistance) && !rayHit.collider.tag.Equals("ground")){

           
            UnityEngine.Debug.Log("Looking at " + rayHit.collider.tag 
            + " and interacting is " + interacting);
           

            if (!interacting){
               
                //We are actively looking at something, so stop analyzing it
                interacting = true;

                //less expensive to access the string of the rayhit just once
                 string tag = rayHit.collider.tag;

                //If we found a tree and we arent already looking at a tree
                if (tag.Equals("tree")){

                    currentObject = rayHit;    
                    createTextOnCursor("Press E for Maple Syrup");
                    currentObject.collider.GetComponent<MapleTreeScript>().showBar();
                    lookingAtTree = true;

                }   
                else if (tag.Equals("igloo")){
                    UnityEngine.Debug.Log("Looking at igloo with raycast");
            
                }   

                else if (tag.Equals("sled")){
                    currentObject = rayHit;    

                    createTextOnCursor("Press E to ride the sled");
                    lookingAtSled = true;
                }
            }
        }
        else {

            //We are no longer looking at an interactable
            interacting = false;

            //If we made text on the screen, destroy it.
            if (textGO)
                Destroy(textGO);

            //If we are looking at a tree, there are additional UI elements to deallocate
            if (lookingAtTree){
            currentObject.collider.GetComponent<MapleTreeScript>().hideBar();
            lookingAtTree = false;
            }
            
            
                         
        }

      
     
    }

    void Update(){

            if (lookingAtTree && Input.GetKeyDown(KeyCode.E)){
                currentObject.transform.GetComponent<MapleTreeScript>().placeBucket(transform.position);
                currentObject.transform.GetComponent<MapleTreeScript>().RemoveHealth(); 
            }
            else if (lookingAtSled && Input.GetKeyDown(KeyCode.E)){
                currentObject.transform.GetComponentInChildren<Sled>().activateSled(gameObject);
            }
    }

    
    void createTextOnCursor(string text){
         //Going to create a text object to put in the canvas
            textGO = new GameObject("Interact Text");

            // Set the canvas as the parent
            textGO.transform.SetParent(mainCanvas.transform);
            textGO.transform.Translate(Screen.width/2, Screen.height/2, 0);

            Text myText = textGO.AddComponent<Text>();
            Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
            myText.font = ArialFont;
            myText.text = text;

    }

}

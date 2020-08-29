using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
    This script handles the player's interaction with the world through the 
    raycast. 
*/
public class InteractScript : MonoBehaviour
{
    public Canvas mainCanvas;
    private GameObject mapleHealthGO;
    private GameObject textGO;
    private RaycastHit currentTree;

    public Camera cam;

    //How far away the looking raycast will go
    const int lookDistance = 8;

    bool lookingAtTree = false;

    //The interacting variable ensures that the ray wont continuously check tags
    bool interacting = false;

    Vector3 behind = new Vector3(2,2,2);
    // Fixed Update is easier on the engine for the raycast. Updates less frequently
    void FixedUpdate()
    {
        
        // Check for what the user is looking at by casting a ray forward from the user
        RaycastHit rayHit;
    
        Ray rayFromPlayer = new Ray(cam.transform.position, cam.transform.forward);
        
        Debug.DrawRay(transform.position, cam.transform.forward, Color.green);

        if (Physics.Raycast(rayFromPlayer, out rayHit, lookDistance)){
            
            if (!interacting){
                //We are actively looking at something, so stop analyzing it
                interacting = true;

                //less expensive to access the string of the rayhit just once
                string tag = rayHit.collider.tag;

                //If we found a tree and we arent already looking at a tree
                if (tag.Equals("tree")){

                    currentTree = rayHit;    
                    createTextOnCursor("Press E for Maple Syrup");
                    currentTree.collider.GetComponent<MapleTreeScript>().showBar();
                    lookingAtTree = true;

                }   
                else if (tag.Equals("igloo")){
                    UnityEngine.Debug.Log("Looking at igloo with raycast");
            
                }   

                else if (tag.Equals("sled")){
                    createTextOnCursor("Press E to ride the sled");
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
            currentTree.collider.GetComponent<MapleTreeScript>().hideBar();
            lookingAtTree = false;
            }
            
            
                         
        }

      
     
    }

    void Update(){

            if (lookingAtTree && Input.GetKeyDown(KeyCode.E)){
                currentTree.transform.GetComponent<MapleTreeScript>().placeBucket(this.transform.position);
                currentTree.transform.GetComponent<MapleTreeScript>().RemoveHealth(); 
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

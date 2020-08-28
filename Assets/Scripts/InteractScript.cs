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

    //How far away the looking raycast will go
    const int lookDistance = 4;

    bool lookingAtTree = false;

    // Fixed Update is easier on the engine for the raycast.
    void FixedUpdate()
    {
        
        // Check for what the user is looking at by casting a ray forward from the user
        RaycastHit rayHit;
    
        Ray rayFromPlayer = new Ray(transform.position, this.transform.forward);
        
        if (Physics.Raycast(rayFromPlayer, out rayHit, lookDistance)){

            //If we found a tree and we arent already looking at a tree
            if (!lookingAtTree && rayHit.collider.tag == "tree"){

            currentTree = rayHit;    
            createTextOnCursor("Press E for Maple Syrup");
            currentTree.collider.GetComponent<MapleTreeScript>().showBar();
            lookingAtTree = true;

            }   
            else if (rayHit.collider.tag == "igloo"){
                UnityEngine.Debug.Log("Looking at igloo with raycast");
        
            }   

        }
        else {
            if (textGO){
                Destroy(textGO);
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
            textGO = new GameObject("Collect Maple Text");

            // Set the canvas as the parent
            textGO.transform.SetParent(mainCanvas.transform);
            textGO.transform.Translate(Screen.width/2, Screen.height/2, 0);

            Text myText = textGO.AddComponent<Text>();
            Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
            myText.font = ArialFont;
            myText.text = text;

    }

}

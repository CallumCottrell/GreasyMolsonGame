
using UnityEngine;


//We aren't going to use this yet. August 11 2020
public class PlayerCollision : MonoBehaviour
{
    public Transform t;
    public GameObject text;

    void OnCollisionEnter(Collision hit){
        
        RaycastHit rayHit;
        Ray landingRay = new Ray(transform.position, Vector3.forward);

        UnityEngine.Debug.Log(hit.gameObject.tag);
        if (hit.gameObject.tag == "tree"){  

            if (Physics.Raycast(landingRay, out rayHit)){
                if (rayHit.collider.tag == "tree"){
                    UnityEngine.Debug.Log("Raycast worked");
                    showText();
                }
            }
        }
    
    }


void showText(){
    Instantiate(text, t.position, Quaternion.identity, t );
}

}


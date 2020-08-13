
using UnityEngine;


//We aren't going to use this yet. August 11 2020
public class PlayerCollision : MonoBehaviour
{
    public Transform t;

    void OnCollisionEnter(Collision hit){

      
        UnityEngine.Debug.Log(hit.gameObject.tag);

        

    }


void showText(){
}

}


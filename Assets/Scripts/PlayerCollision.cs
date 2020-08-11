
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    
    void OnCollisionEnter(Collision hit){
        UnityEngine.Debug.Log(hit.gameObject.tag);
        if (hit.gameObject.tag == "tree"){  
        }
    
    }

}


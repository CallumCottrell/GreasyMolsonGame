
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision hit){
        UnityEngine.Debug.Log(hit.gameObject.name);
        if (hit.gameObject.name == "tree"){
            
        }
    }
}

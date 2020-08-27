using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallCollision : MonoBehaviour
{
  
  void OnCollisionEnter(Collision hit){

      
      if (hit.gameObject.tag != "Untagged"){
        UnityEngine.Debug.Log(hit.gameObject.tag);
        Destroy(this.gameObject);
      }

    }
}

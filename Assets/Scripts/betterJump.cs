using UnityEngine;


public class betterJump : MonoBehaviour 
{

 public float fallMultiplier = 2.5f;
 public float lowJumpMultiplier = 2f;

 Rigidbody rb;

 void Awake()
 {
  rb = GetComponent<Rigidbody>();
 } 

 void Update()
 {
  if(rb.velocity.y < 0)
  {
   rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
  }
 }
}
using UnityEngine;
using UnityEngine.UI;


/* 
This script handles everything to do with throwing the snow ball

Callum Cottrell 8/28/20
*/
public class SnowBallThrowing : MonoBehaviour
{

//Camera will help decide where the ball is going to fly
    public Camera playerCamera;

    // The rigid body of the snowBall is required for quickly instantiating
    public Rigidbody snowBall;
    
    public GameObject snowBallVelocityBar;

    public float minSnowBallVelocity = 1f;
    public float maxSnowBallVelocity = 30f;

    public float rotationSpeed;

    private float snowBallVelocity = 1f;
    // Update is called once per frame
    void Update()
    {
        snowBallVelocityBar.GetComponent<Slider>().value = snowBallVelocity;

        if (Input.GetKeyDown(KeyCode.G)){
            
        }
        else if (Input.GetKey(KeyCode.G)){
              snowBallVelocity += 0.1f;

        }
        else if (Input.GetKeyUp(KeyCode.G)) {
             fireSnowBall();                    
        } 
        
        
    }

    void fireSnowBall(){
        Rigidbody snowInstance = Instantiate(snowBall, playerCamera.transform.position, playerCamera.transform.rotation) as Rigidbody;
        transform.localEulerAngles += transform.forward * rotationSpeed * Time.deltaTime;
        //snowInstance.velocity = snowBallVelocity * playerCamera.transform.forward;
        snowBallVelocity = 1f;
    }
}

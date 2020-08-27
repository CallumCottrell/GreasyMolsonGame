using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TreeHealth : MonoBehaviour {

    public GameObject MapleHealthBar;

    public GameObject bucket;
    void Start(){
        //MapleHealthBar.GetComponent<Slider>().value = health;
    }

    public float health = 100f;
    public void RemoveHealth(float amount)
    {
        if (health > 0)
        health -= amount;

        MapleHealthBar.GetComponent<Slider>().value = health;
    
    }

    public void hideBar(){
        MapleHealthBar.GetComponent<CanvasGroup>().alpha = 0 ;
        
    }

    public void showBar(){
        MapleHealthBar.GetComponent<Slider>().value = health;
        MapleHealthBar.GetComponent<CanvasGroup>().alpha = 1;
    }

    public void placeBucket(Vector3 playerDirection){
         UnityEngine.Debug.Log("this.transform.position.x " + this.transform.position.x);
         UnityEngine.Debug.Log("playerDirection.x " + playerDirection.x);

       // float diffX = Mathf.Abs((this.transform.position.x - playerDirection.x) / 4);
        float diffX = (playerDirection.x - this.transform.position.x) / 8;
         UnityEngine.Debug.Log("diffX" + diffX);
        float diffZ = (playerDirection.z - this.transform.position.z) / 8;
       // float diffZ = Mathf.Abs((this.transform.position.z - playerDirection.z) / 4);           
        Vector3 bucketPlacement = new Vector3(this.transform.position.x + diffX, -3f , this.transform.position.z + diffZ);
        
        Instantiate(bucket, bucketPlacement, bucket.transform.rotation );
    }

}
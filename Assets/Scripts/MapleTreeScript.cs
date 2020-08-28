using UnityEngine;
using UnityEngine.UI;

/*
This script handles everything to do with managing the tree. 

showBar() and hideBar() are called by InteractScript

Callum Cottrell 8/28/20
*/
public class MapleTreeScript : MonoBehaviour {
    
    
    //The prefab in the UI folder
    public GameObject MapleBarPrefab;

    //The gameobject for representing the bar
    private GameObject syrupBar;

    public Canvas mainCanvas;

    public GameObject bucket;

    private int health = 100;

    private const int amount = 10;

    public void RemoveHealth()
    {
        if (health > 0)
        health -= amount;

        syrupBar.GetComponent<Slider>().value = health;
    
    }

    public void hideBar(){

        Destroy(syrupBar);

        //In order to delete the bucket i need to create a gameobject
        //instantiating it wont allow me to delete it later for reasons
        //I dont understand at the moment
        
        //Destroy(bucket);
    }

    public void showBar(){

        syrupBar = Instantiate(MapleBarPrefab) as GameObject;
        
        syrupBar.transform.SetParent(mainCanvas.transform, false);
        
        syrupBar.GetComponent<Slider>().value = health;
        
    }

    public void placeBucket(Vector3 playerDirection){

        float diffX = (playerDirection.x - this.transform.position.x) / 7;
        float diffZ = (playerDirection.z - this.transform.position.z) / 7;

        Vector3 bucketPlacement = new Vector3(this.transform.position.x + diffX, 2.7f , this.transform.position.z + diffZ);
        
        Instantiate(bucket, bucketPlacement, bucket.transform.rotation );
    }

}
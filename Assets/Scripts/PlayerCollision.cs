
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    
    public GameObject FloatingTextPrefab;
    

    void OnCollisionEnter(Collision hit){
        UnityEngine.Debug.Log(hit.gameObject.name);
        if (hit.gameObject.name == "tree"){  
        }
        
        if (FloatingTextPrefab)
        {
        showFloatingText();

        }
    }
  

    
    
    void showFloatingText()
    {
        Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
    }

}


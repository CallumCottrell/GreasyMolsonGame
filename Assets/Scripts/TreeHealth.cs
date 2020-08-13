using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHealth : MonoBehaviour {

    public float health = 100f;
    public void RemoveHealth(float amount)
    {
        if (health > 0)
        health -= amount;

    
    }


}
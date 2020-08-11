using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHealth : MonoBehaviour {

    public float health = 100f;
    public void RemoveHealth(float amount)
    {
        health -= amount;

        UnityEngine.Debug.Log(health);
        if(health <= 0)
        {
            ///do something when health (syrup runs out, some kind of text that says wait)
        }
    }
}
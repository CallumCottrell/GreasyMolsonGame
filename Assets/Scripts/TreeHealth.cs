using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TreeHealth : MonoBehaviour {

    public GameObject MapleHealthBar;

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

}
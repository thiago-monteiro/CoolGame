using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearBot : MonoBehaviour
{
    public static GearBot self;
    public int health = 10;
    void OnEnable()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Bullet"){
            health--;
            if (health < 1){
                gameObject.SetActive(false);
            }
        }
    }

    void OnDisable(){
        //explosion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

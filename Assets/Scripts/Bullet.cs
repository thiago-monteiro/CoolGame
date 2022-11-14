using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = Dude.self.transform.position;
        transform.rotation = Dude.self.transform.rotation;
    }
    void OnCollisionEnter2D(Collision2D collision){
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate(){
        rb.AddForce(new Vector2(16, 0));
        if (transform.position.x - Dude.self.transform.position.x > 100 || transform.position.x - Dude.self.transform.position.x < -100){
            gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dude : MonoBehaviour
{
    public static Dude self;
    Rigidbody2D rb;
    private float speed;
    public float jumpVelocity = -1;
    public Animator animator;
    public bool isJumping = false;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        self = this;
        speed = 3f;
        rb = GetComponent<Rigidbody2D>();
        Pooler.self.GetGearBot();
    }

    void Move(){
        //rb.AddForce(new Vector2(4, 0));
       if (Input.GetAxisRaw("Horizontal") > 0){
           transform.localScale = new Vector2(4f, 4f);
           animator.SetInteger("Direction", 1);
       }else if(Input.GetAxisRaw("Horizontal") < 0){
           transform.localScale = new Vector2(-4f, 4f);
           animator.SetInteger("Direction", 1);
       }else{
           animator.SetInteger("Direction", 0);
       }
       if (Input.GetKeyDown(KeyCode.Space) && isJumping == false){
           animator.SetBool("Jumping", true);
           isJumping = true;
           jumpVelocity = 0;
       }     
       if (isJumping && jumpVelocity < 8){
           jumpVelocity += 1;
           rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), jumpVelocity) * speed;
       }else{
           rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), -rb.gravityScale) * speed;
       }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Platform"){
            isJumping = false;
            animator.SetBool("Jumping", false);
            animator.SetInteger("Direction", 0);
        }
    }
    void Shoot(){
        if (Input.GetKeyDown(KeyCode.Return)){
            Bullet bullet = Pooler.self.GetBullet();
            Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void FixedUpdate(){
        Move();
        Shoot();
    }
}

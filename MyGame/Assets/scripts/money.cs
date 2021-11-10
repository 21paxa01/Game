using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class money : MonoBehaviour
{
    public Rigidbody2D rb;
    public int test = 0;
    public Animator anim;
    public Collider2D coll;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }
    void Update()
    {
        if(transform.position.y<= -3.011614f)
        {
            Drop();
        }
       // Magnet();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            coll.isTrigger = true;
            test++;
            if (test > 0)
            {
                Destroy(gameObject);
                MoneyCount.mon++;
            }
        }        
    }
    private int testik = 0;
    void Drop()
    {
        if (testik == 0)
        {
            anim.SetBool("drop", true);
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            rb.gravityScale = 0f;
            rb.constraints = RigidbodyConstraints2D.None;
            coll.isTrigger = true;
            testik++;
        }
    }
    public float hor_speed;
    public float ver_speed;
    public bool t1;
    public bool t2;
    public bool t3;
    public bool t4;
    public float test1;
    public float test2;
   /* void Magnet()
    {
        if (transform.position.x < bill.hor_position)
        {
            rb.velocity = new Vector2(hor_speed, rb.velocity.y);
            t1 = true;
        }
        if (transform.position.x > bill.hor_position)
        {
            t2 = true;
            rb.velocity = new Vector2(-hor_speed, rb.velocity.y);
        }

        if (transform.position.y > bill.ver_position+0.2f)
        {
            t3 = true;
            rb.velocity = new Vector2(rb.velocity.x, -ver_speed);
        }
        if (transform.position.y < bill.ver_position+0.2f)
        {
            t4 = true;
            rb.velocity = new Vector2(rb.velocity.x, ver_speed);
        }       
    }*/
    
}

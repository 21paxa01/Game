using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class money : MonoBehaviour
{
    public Rigidbody2D rb;
    public int test = 0;
    public Transform bill;
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
       // if (bill.position.x == transform.position.x)
        //    rb.velocity = new Vector2(0f, rb.velocity.y) ;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            coll.isTrigger = true;
            test++;
           // rb.gravityScale = 0.1f;
            if (test > 1)
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
    
}

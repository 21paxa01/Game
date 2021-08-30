using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class money : MonoBehaviour
{
    public Rigidbody2D rb;
    public int test = 0;
    public Animator anim;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "road u")
        {

            anim.SetBool("drop", true);
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            rb.gravityScale = 0f;
            rb.constraints = RigidbodyConstraints2D.None;


        }
        if (other.CompareTag("Player"))
        {
            test++;
           // rb.gravityScale = 0.1f;
            if (test > 1)
            {
                Destroy(gameObject);
                MoneyCount.mon++;
            }
        }        
    }
    
}

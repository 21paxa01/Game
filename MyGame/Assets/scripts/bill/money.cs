using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class money : MonoBehaviour
{
    public Rigidbody2D rb;
    public int test = 0;
    public Animator anim;
    public Collider2D coll;
    public MoneyCount script;
    private MoneyMagnet magnet_script;
    void Start()
    {
        script = GameObject.Find("MoneyCount").GetComponent<MoneyCount>();
        rb= GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        magnet_script = GetComponent<MoneyMagnet>();
    }
    void Update()
    {
        if(transform.position.y<= -3.011614f)
        {
            anim.SetBool("drop", true);
            transform.position = new Vector3(transform.position.x, -3.011614f, transform.position.z);
            rb.gravityScale = 0f;
        }
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            MoneyCount.mon++;
            script.Save();
        }        
    }
    private int testik = 0;
    void Drop()
    {
        if (testik == 0)
        {
            rb.gravityScale = 0f;
            testik++;
        }
    }
   
    
}

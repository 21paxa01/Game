using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class money : MonoBehaviour
{
    public Rigidbody2D rb;
    public int test = 0;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "road u")
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
        
    }
    
}

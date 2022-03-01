using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bill_icon : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);        
    }
}

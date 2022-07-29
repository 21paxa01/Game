using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOUIS : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform bill;
    private float rb_x, rb_y;
    public bool red;
    public Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        red = false;
    }

    void Update()
    {
        anim.SetBool("red", red);
        rb.velocity = new Vector2(rb_x, rb_y);
        if (bill.rotation.y !=-1)
        {
            if (bill.position.x - 0.3f > transform.position.x)
            {
                rb_x = 1f;
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            else if (bill.position.x - 0.2f < transform.position.x)
            {
                rb_x = -1f;
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            else
            {
                rb_x = 0f;
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            if (bill.position.y + 0.35f > transform.position.y)
                rb_y = 0.5f;
            else if (bill.position.y + 0.45f < transform.position.y)
                rb_y = -0.5f;
            else
                rb_y = 0f;
        }
        else
        {
            if (bill.position.x + 0.2f > transform.position.x)
            {
                rb_x = 1f;
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            else if (bill.position.x + 0.3f < transform.position.x)
            {
                rb_x = -1f;
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            else
            {
                rb_x = 0f;
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
                if (bill.position.y + 0.35f > transform.position.y)
                rb_y = 0.5f;
            else if (bill.position.y + 0.45f < transform.position.y)
                rb_y = -0.5f;
            else
                rb_y = 0f;
        }

    }
    public void ToBill()
    {
        if (bill.rotation.y != -1)
            transform.position = new Vector3(bill.position.x - 0.25f, bill.position.y + 0.4f, bill.position.z);
        else
            transform.position = new Vector3(bill.position.x + 0.25f, bill.position.y + 0.4f, bill.position.z);
    }
}

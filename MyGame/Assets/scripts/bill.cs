using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bill : MonoBehaviour 
{
    
    public Rigidbody2D rb;
    public Animator anim;
    public Joystick joystick_move;
    public Joystick joystick_shot;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        GroundCheckRadius = GroundCheck.GetComponent<CircleCollider2D>().radius;
    }
    
    void Update()
    {
        Walk();
        Reflect();
        Jump();
        CheckingGround();
    }
    
    public Vector2 moveVector;
    public Vector2 moveVector_1;
    public int speed = 3;
    private bool right = false;
    private bool left = false;
    void Walk()
    {
        float rotateZ = Mathf.Atan2(joystick_move.Vertical, joystick_move.Horizontal) * Mathf.Rad2Deg;
        moveVector.x = joystick_move.Horizontal;
        if(rotateZ < 90 && rotateZ > -90)
        {
            right=true;
            left = false;
        }
        else
        {
            right = false;
            left = true;
        }
        if (transform.position.x > -3.7f && transform.position.x < 16.5f)
        {
            rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
        }
        else if(transform.position.x <= -3.7f&& right)
        {
            rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
        }
        else if (transform.position.x >= 16.5f && left)
        {
            rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
    }
    
    public bool faceRight = true;
    void Reflect()
    {
        moveVector_1.x = joystick_shot.Horizontal;
        if (moveVector_1.x>0 && !faceRight )
        {
            transform.Rotate(0f, 180f, 0f);
            faceRight = !faceRight;
        }
        if (moveVector_1.x < 0 && faceRight)
        {
            transform.Rotate(0f, 180f, 0f);
            faceRight = !faceRight;
        }
    }
    
    public int jumpForce = 10;
    
    void Jump()
    {
        float verticalMove = joystick_move.Vertical;
        if (onGround && verticalMove>=0.5f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }


    public bool onGround;
    public LayerMask Ground;
    public Transform GroundCheck;
    private float GroundCheckRadius;
    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, Ground);
        anim.SetBool("onGround", onGround);
    }
    
}
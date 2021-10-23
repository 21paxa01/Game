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
    private bool move=true;
    private bool jump = false;
    public float hp;
    public static float HP;

    public GameObject weapons;
    public GameObject rapt_menu;
    public GameObject shot_joustick;
    public GameObject change_button;

    public AudioSource stairs_sound;
    public GameObject stairs;
    public bool upStairs = false;

    public Collider2D coll;
    public Image bar;
    public Image back;
    public float fill;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        GroundCheckRadius = GroundCheck.GetComponent<CircleCollider2D>().radius;
        fill = 1f;
        HP = hp;
        faceRight = true;
        change_button.SetActive(false);
        weapons.SetActive(false);
        shot_joustick.SetActive(false);
        rapt_menu.SetActive(false);
    }
    public bool test;
    void Update()
    {
        bar.fillAmount = fill;
        fill =HP / hp;
        if (fill <= 0)
        {
            anim.SetBool("death", true);
            weapons.SetActive(false);
        }
        else
        {
            Walk();
            Reflect();
            test = faceRight;
            Jump();
            CheckingGround();
            Stairs();
        }
       
    }
    
    public Vector2 moveVector;
    public Vector2 moveVector_1;
    public float speed = 3f;
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
        if (move == true)
        {
            if (transform.position.x > -3.7f && transform.position.x < 16.5f)
            {
                rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
            }
            else if (transform.position.x <= -3.7f && right)
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
        }
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
    }
    
    public static bool faceRight = true;
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
        if (jump == true)
        {
            if (onGround && verticalMove >= 0.5f)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
    }


    public bool onGround;
    public LayerMask Ground;
    public Transform GroundCheck;
    private float GroundCheckRadius;


    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, Ground);
        if (!onGround)
        {
            speed = 1.5f;
        }
        else
        {
            speed = 1f;
        }
        anim.SetBool("onGround", onGround);
    }
    void Stairs()
    {
        if (transform.position.y < -3f)
        {
            if (transform.position.x >= 5.959f && transform.position.x <= 6.16f)
            {
                stairs.SetActive(true);
                if (off == true)
                    stairs.SetActive(false);
                if (upStairs == true)
                {
                    transform.position = new Vector2(6.078f, transform.position.y);
                    move = false;
                    coll.isTrigger = true;
                    rb.velocity = new Vector2(0f, speed);
                }
            }
            if (transform.position.x < 5.959f || transform.position.x > 6.16f)
            {
                stairs.SetActive(false);
            }
        }
        else if (transform.position.y > -3.1f && transform.position.y < -3f)
        {
            rb.velocity = new Vector2(speed * 1.5f, speed * 3.5f);
            
        }
        else
        {
            change_button.SetActive(true);
            weapons.SetActive(true);
            shot_joustick.SetActive(true);
            rapt_menu.SetActive(true);
            luk_off.off_luk = true;
            move = true;
            jump = true;
            stairs.SetActive(false);
            coll.isTrigger = false;
            upStairs = false;
        }
        
        



    }
    public void UpStairs()
    {
        upStairs = true;
        stairs_sound.Play();
    }
    private bool off;
    public void Button_off()
    {
        off = true;
    }
    public AudioSource shag;
    public void Start_shag()
    {
        if (transform.position.y < -3.1f)
            StartCoroutine(Shag());
    }
    public void Stop_shag()
    {
   
        StopCoroutine(Shag());
    }
    IEnumerator Shag()
    {
        while (1 > 0)
        {
            shag.Play();
            yield return new WaitForSeconds(0.8f);
        }
    }

}
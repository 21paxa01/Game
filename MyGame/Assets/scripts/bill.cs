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
    public GameObject Wave;
    public GameObject ammo;
    public GameObject Inventory;
    public GameObject Mechanik;
    public bool weapon_chek;

    public GameObject weapons;
    public GameObject torg;
    public GameObject rapt_menu;
    public GameObject shot_joustick;
    public GameObject change_button;
    public GameObject computer;

    public AudioSource stairs_sound;
    public GameObject stairs;
    public GameObject choise;
    public GameObject home;
    public bool upStairs = false;

    public Collider2D coll;
    public Image bar;
    public Image back;
    public float fill;
    public static bool OnRoad;

    public static float ver_position;
    public static float hor_position;

    private AudioSource[] shagi;
    public AudioSource shag_1;
    public AudioSource shag_2;
    public AudioSource shag_3;
    public AudioSource shag_4;
    public AudioSource shag_5;
    private int rand;
    void Start()
    {
        weapon_chek = false;
        shagi = new AudioSource[5];
        shagi[0] = shag_1;shagi[1] = shag_2;shagi[2] = shag_3;shagi[3] = shag_4;shagi[4] = shag_5;
        OnRoad = false;
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
        ver_position = transform.position.y;
        hor_position = transform.position.x;
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
            Jump();
            if (transform.position.x > 5.3f && transform.position.x < 5.8f && transform.position.y > -5f && transform.position.y < -4f)
                Inventory.SetActive(true);
            else
                Inventory.SetActive(false);
            if (transform.position.x > 4f && transform.position.x < 4.35f && transform.position.y > -5f && transform.position.y < -4f)
            {
                choise.SetActive(true);
            }
            else
            {
                choise.SetActive(false);
            }
            if (transform.position.x > 4.5f && transform.position.x < 4.9f && transform.position.y > -5f && transform.position.y < -4f)
            {
                computer.SetActive(true);
            }
            else
            {
                computer.SetActive(false);
            }
            if (transform.position.x > 4.1f && transform.position.x < 4.45f && transform.position.y <-6f && transform.position.y > -12f && torgovets.shop == false)
                 torg.SetActive(true);
            else
                torg.SetActive(false);
            if (transform.position.x > 6.2f && transform.position.x < 6.9f && transform.position.y < -6f&& transform.position.y>-12f)
            {
                shop_door.open = true;
                home.SetActive(true);
            }
            else if (transform.position.x > 4.8f && transform.position.x < 5.4f && transform.position.y < -15f && transform.position.y > -16f)
            {
                home.SetActive(true);
            }
            else
            {
                shop_door.open = false;
                home.SetActive(false);
            }
            if (transform.position.x > 5.7f && transform.position.x < 6.5f && transform.position.y < -15f && transform.position.y > -16f)
            {
                mechanik.down = true;
                Mechanik.SetActive(true);
            }
            else
            {
                mechanik.down = false;
                Mechanik.SetActive(false);
            }
            CheckingGround();
            Stairs();
        }
       
    }
    
    public Vector2 moveVector;
    public Vector2 moveVector_1;
    public float speed;
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
        if (transform.position.y > -4f)
        {
            moveVector_1.x = joystick_shot.Horizontal;
        }
        else
        {
            moveVector_1.x = joystick_move.Horizontal;
        }
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
            speed = 1.75f;
        }
        else
        {
            speed = 1.5f;
        }
        anim.SetBool("onGround", onGround);
    }
    void Stairs()
    {
        if (OnRoad == false)
        {
            if (transform.position.y < -3f && transform.position.y > -6f)
            {
                if (transform.position.x >= 5.959f && transform.position.x <= 6.16f && weapon_chek == true)
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
            else if (transform.position.y > -3f)
            {
                ZoomCamera.zoom = 2f;
                OnRoad = true;
                ammo.SetActive(true);
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
                Wave.SetActive(true);
            }
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
        spawn.start = true;
        off = true;
    }
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
            rand = Random.Range(0, 5);
            shagi[rand].Play();
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void OnColligionEnter2D(Collider2D other)
    {
        
        if (other.name == "wall(Clone)" )
        {
            rb.velocity = new Vector2(moveVector.x * -2*speed, rb.velocity.y);
            test = true;
        }
        

    }
    public void Open_Shop()
    {
        torgovets.shop = true;
        transform.position =new Vector3 (4.22f, transform.position.y, transform.position.z);
    }
    public void Open_Lab()
    {
        mechanik_shop.lab = true;
        transform.position = new Vector3(5.8f, transform.position.y, transform.position.z);
    }
    public void REspawn()
    {
        StartCoroutine(respawn());
    }
    public GameObject perechod;
    IEnumerator respawn()
    {
        perechod.SetActive(true);
        yield  return new WaitForSeconds(1f);
        off = false;
        wave_img.victory = false;
        Wave.SetActive(false);
        ammo.SetActive(false);
        jump = false;
        change_button.SetActive(false);
        weapons.SetActive(false);
        shot_joustick.SetActive(false);
        rapt_menu.SetActive(false);
        ZoomCamera.zoom = 0.7f;
        anim.SetBool("death", false);
        transform.position = new Vector3(5.08f, -4.98126411f, 0f);
        yield return new WaitForSeconds(1f);
        perechod.SetActive(false);
    }
}
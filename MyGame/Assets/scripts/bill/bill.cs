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
    private float inv_hp;
    public GameObject Wave;
    public GameObject ammo;
    private bool ammo_chek;
    public GameObject Inventory;
    public GameObject Mechanik;
    public bool weapon_chek;
    public bool death;
    public GameObject panel;
    public RectTransform money_icon;

    public GameObject reload_button;
    public GameObject weapons;
    public GameObject torg;
    public GameObject rapt_menu;
    public GameObject shot_joustick;
    public GameObject computer;
    public GameObject grenage_cell_1,grenage_cell_2;
    private granade_cell cell_script;

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

    public GameObject defoalt, travler, punk, zombie;
    private GameObject[] skins_arr;
    public int s_i;
    private AudioSource[] shagi;
    public AudioSource shag_1;
    public AudioSource shag_2;
    public AudioSource shag_3;
    public AudioSource shag_4;
    public AudioSource shag_5;
    private int rand;
    public SpriteRenderer sprite;
    private change_weapon script;
    public GameObject for_home;
    public GameObject rain;
    private SpriteRenderer rain_sp;
    private bool shag;
    public GameObject louis;
    private LOUIS lui;
    private shield_for_bill shield;
    private spawn spawn;
    void Start()
    {
        shield = GetComponent<shield_for_bill>();
        panel.SetActive(false);
        lui = louis.GetComponent<LOUIS>();
        louis.SetActive(false);
        sprite = GetComponent<SpriteRenderer>();
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
        inv_hp = HP;
        ammo_chek = false;
        faceRight = true;
        weapons.SetActive(false);
        shot_joustick.SetActive(false);
        rapt_menu.SetActive(false);
        script = GetComponent<change_weapon>();
        money_icon.anchoredPosition = new Vector2(-375f, 160f);
        skins_arr = new GameObject[4];
        skins_arr[0] = defoalt;skins_arr[1] = travler;skins_arr[2] = punk;skins_arr[3] = zombie;
    }
    public int test;
    public bool stop;
    public bool skin;
    void Update()
    {
        /*if (inv_hp > HP&&invulnerability==false)
        {
            invulnerability = true;
            inv_hp = HP;
            StartCoroutine(Invulnerability());
        }*/
        ver_position = transform.position.y;
        hor_position = transform.position.x;
        bar.fillAmount = fill;
        fill =HP / hp;
        if (fill <= 0)
        {
            death = true;
            //anim.SetBool("death", death);
            weapons.SetActive(false);
        }
        else if (fill > 0 && stop == false&& torgovets.shop == false && mechanik_shop.lab == false)
        {
            if (ammo_chek == true)
            {
                if (script.reload[change_weapon.change] == true)
                    ammo.SetActive(true);
                else
                    ammo.SetActive(false);
            }
            Walk();
            Reflect();
            Jump();
            if(transform.position.x > 16.5f)
            {
                if(transform.position.y< -3.082081f)
                    transform.position = new Vector3(16.5f, -3.082081f, 0f);
                else
                    transform.position = new Vector3(16.5f, transform.position.y, 0f);
            }
            if(transform.position.x < -3.7f)
            {
                if (transform.position.y < -3.082081f)
                    transform.position = new Vector3(-3.7f, -3.082081f, 0f);
                else
                    transform.position = new Vector3(-3.7f, transform.position.y, 0f);
            }
            if (transform.position.x > 6.3f && transform.position.x < 6.6f && transform.position.y > -5f && transform.position.y < -4f)
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
            if (transform.position.x > 4.1f && transform.position.x < 4.45f && transform.position.y < -6f && transform.position.y > -12f && torgovets.shop == false)
                torg.SetActive(true);
            else
                torg.SetActive(false);
            if (transform.position.x > 6.2f && transform.position.x < 6.9f && transform.position.y < -6f && transform.position.y > -12f)
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
    public float moveX;
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
        moveX = Mathf.Abs(moveVector.x);
        //anim.SetFloat("moveX", moveX);
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

    public float testik;
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
        //anim.SetBool("onGround", onGround);
    }
    public SpriteRenderer road_sprite;
    void Stairs()
    {
        for_home = GameObject.Find("for_home");
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
                        perechod.SetActive(true);
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
                if (spawn.rain == true)
                {
                    rain = GameObject.Find("rain");
                    rain_sp = rain.GetComponent<SpriteRenderer>();
                    rain_sp.sortingOrder = 30;
                    rain = GameObject.Find("rain_2");
                    rain_sp = rain.GetComponent<SpriteRenderer>();
                    rain_sp.sortingOrder = 30;
                }
                road_sprite.sortingOrder = 21;
                for_home.SetActive(false);
                perechod.SetActive(false);
                panel.SetActive(true);
                ZoomCamera.zoom = 2f;
                money_icon.anchoredPosition = new Vector2(-75f, -143f);
                ShopCamera.y = -0.4f;
                testik = -0.4f;
                OnRoad = true;
                ammo_chek = true;
                weapons.SetActive(true);
                shot_joustick.SetActive(true);
                //rapt_menu.SetActive(true);
                luk_off.off_luk = true;
                move = true;
                script.Reload_chek();
                jump = true;
                stairs.SetActive(false);
                coll.isTrigger = false;
                upStairs = false;
                Wave.SetActive(true);
                louis.SetActive(true);
                lui.ToBill();
            }
        }
    }
    public void UpStairs()
    {
        upStairs = true;
        road_sprite = GameObject.Find("new_road").GetComponent<SpriteRenderer>();
        stairs_sound.Play();
    }
    private bool off;
    public void Button_off()
    {
        spawn.start = true;
        bird_spawn.start = true;
        off = true;
    }
    public void Start_shag()
    {
        if (transform.position.y < -3.1f)
        {
            shag = true;
            StartCoroutine(Shag());
        }
    }
    public void Stop_shag()
    {
        shag = false;
    }
    IEnumerator Shag()
    {
        while (shag==true)
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
        }
        

    }
    public void Open_Shop()
    {
        torgovets.shop = true;
        stop = true;
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector3(4.22f, transform.position.y, transform.position.z);

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
        if(skin==false)
            sprite.color = new Color(1f, 1f, 1f, 1f);
        invulnerability = false;
        perechod.SetActive(true);
        yield  return new WaitForSeconds(1f);
        shield.HP = shield.hp;
        rain = GameObject.Find("rain");
        rain_sp = rain.GetComponent<SpriteRenderer>();
        rain_sp.sortingOrder = -10;
        rain = GameObject.Find("rain_2");
        rain_sp = rain.GetComponent<SpriteRenderer>();
        rain_sp.sortingOrder = -10;
        cell_script = grenage_cell_1.GetComponent<granade_cell>();
        cell_script.Update_cell();
        cell_script = grenage_cell_2.GetComponent<granade_cell>();
        cell_script.Update_cell();
        louis.SetActive(false);
        panel.SetActive(false);
        money_icon.anchoredPosition = new Vector2(-375f, 160f);
        off = false;
        wave_img.victory = false;
        Wave.SetActive(false);
        ammo.SetActive(false);
        jump = false;
        inv_hp = 100f;
        weapons.SetActive(false);
        shot_joustick.SetActive(false);
        rapt_menu.SetActive(false);
        ZoomCamera.zoom = 0.7f;
        death = false;
        //anim.SetBool("death", death);
        transform.position = new Vector3(5.08f, -4.98126411f, 0f);
        ShopCamera.y = 0f;
        reload_button.SetActive(false);
        ammo_chek = false;
        yield return new WaitForSeconds(1f);
        perechod.SetActive(false);
    }
    public int kef=1;
    public bool invulnerability;
    IEnumerator Discard()
    {
        stop = true;
        rb.velocity = new Vector2(kef*speed, speed);
        yield return new WaitForSeconds(0.2f);
        stop = false;
        //StartCoroutine(Invulnerability());
    }
    public void discard()
    {
        StartCoroutine(Invulnerability());
    }
    IEnumerator Invulnerability()
    {
        invulnerability = true;
        stop = true;
        rb.velocity = new Vector2(kef * speed, speed);
        sprite = skins_arr[s_i].GetComponent<SpriteRenderer>();
        for (int i = 0; i < 6; i++)
        {
            sprite.color = new Color(1f, 0f, 0f, 1f);
            yield return new WaitForSeconds(0.05f);
            sprite.color = new Color(1f, 0f, 0f, 0f);
            yield return new WaitForSeconds(0.05f);
            if (i == 2)
                stop = false;
            test = i;
        }
        sprite.color = new Color(1f, 1f, 1f, 1f);
        invulnerability = false;
    }
}
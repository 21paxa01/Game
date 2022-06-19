using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class martin : MonoBehaviour
{
    private Rigidbody2D physik;
    public GameObject player;
    public Animator anim;
    public bool fight;
    public bool death;
    public float zombie_damage;
    private float zomb_damage;
    public float atack_time;
    private float at_time = 0f;
    private float distToPlayer;
    Coroutine damage;
    public float boom_radius;
    private bool dam_to_bill;
    public zombie_debaffs debaff;
    public GameObject money;
    public Transform money_spawn;
    public GameObject zombie_hp;
    private zombie_hp script;

    public SpriteRenderer sprite;
    public float default_speed;
    public float speed;
    public float HP;
    private float hp = 0;

    private bill bill;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        debaff = GetComponent<zombie_debaffs>();
        physik = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Bill");
        anim = GetComponent<Animator>();
        zomb_damage = zombie_damage;
        script = zombie_hp.gameObject.GetComponent<zombie_hp>();
        HP = script.HP;
        bill = player.GetComponent<bill>();
    }
    public float dist_to_player;
    void Update()
    {
        if (debaff.freeze == true)
        {
            speed = default_speed / 2;
            sprite.color = new Color(0.2745f, 0.4117f, 1f, 1f);
        }
        else
        {
            speed = default_speed;
            sprite.color = new Color(1f, 1f, 1f, 1f);
        }

        hp = script.hp;
        distToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (distToPlayer <= dist_to_player)
        {
            physik.velocity = new Vector2(0, 0);
            StartCoroutine(Die());


        }

        if (player.transform.position.x < transform.position.x && distToPlayer > dist_to_player && death == false)
        {
            physik.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector2(-1, 1);
        }
        if (player.transform.position.x > transform.position.x && distToPlayer > dist_to_player && death == false)
        {
            physik.velocity = new Vector2(+speed, 0);
            transform.localScale = new Vector2(1, 1);
        }
        if (WALL == true)
        {
            physik.velocity = new Vector2(0, 0);
        }
        if (hp >= HP&&death==false)
        {
            death = true;
            physik.velocity = new Vector2(0, 0);
            StartCoroutine(Die());
        }
    }
    private bool WALL;
    private float zomb_wall_pos;
    private wall script_w;
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == "wall(Clone)" || other.name == "boom(Clone)")
        {
            WALL = true;
            zomb_wall_pos = transform.position.x - player.transform.position.x;
            StartCoroutine(WALL_Die(other.gameObject));

        }
        if (other.name == "Bill")
        {
            if (player.transform.position.x > transform.position.x)
                bill.kef = 1;
            else
                bill.kef = -1;
            if (bill.invulnerability == false)
            {
                bill.discard();
                bill.HP -= zombie_damage;
            }
        }
    }
    private int dam = 0;
    public float test = 100f;
    IEnumerator WALL_Die(GameObject w)
    {
        death = true;
        anim.SetBool("death", death);
        script_w = w.gameObject.GetComponent<wall>();
        yield return new WaitForSeconds(script.death_time);
        Instantiate(money, money_spawn.position, transform.rotation);
        script_w.hp -=zombie_damage;
        if (distToPlayer <= boom_radius)
            dam_to_bill = true;
        if (dam_to_bill == true)
        {
            if (player.transform.position.x > transform.position.x)
                bill.kef = 2;
            else
                bill.kef = -2;
            if (bill.invulnerability == false)
            {
                bill.discard();
                bill.HP -= zombie_damage;
            }
        }
        Destroy(gameObject);
    }
    IEnumerator Die()
    {
        death = true;
        anim.SetBool("death", death);
        yield return new WaitForSeconds(script.death_time);
        Instantiate(money, money_spawn.position, transform.rotation);
        if (distToPlayer <= boom_radius)
            dam_to_bill = true;
        if (dam_to_bill == true)
        {
            if (player.transform.position.x > transform.position.x)
                bill.kef = 2;
            else
                bill.kef = -2;
            if (bill.invulnerability == false)
            {
                bill.discard();
                bill.HP -= zombie_damage;
            }
        }
        Destroy(gameObject);
        hp = 0;
    }
    




}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mike : MonoBehaviour
{
    private Rigidbody2D physik;
    public GameObject player;
    public Animator anim;
    public bool fight;
    public bool death;
    public bool stop=false;
    public float zombie_damage;
    private float zomb_damage;
    public float atack_time;
    public float distToPlayer;
    public GameObject shield;
    public zombie_debaffs debaff;
    private int kef;
    public GameObject money;
    public Transform money_spawn;
    public GameObject zombie_hp;
    private zombie_hp script;

    public SpriteRenderer sprite;
    public float default_speed;
    public float speed;
    public float HP;
    private float hp = 0;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        debaff = GetComponent<zombie_debaffs>();
        physik = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.Find("Bill");
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
        if (stop == false)
        {
            if (distToPlayer <= dist_to_player)
            {
                stop = true;
                physik.velocity = new Vector2(0, 0);
                fight = true;
                anim.SetBool("fight", fight);
                if (player.transform.position.x > transform.position.x)
                {
                    kef = 1;
                    transform.localScale = new Vector2(1, 1);
                }
                else
                {
                    kef = -1;
                    transform.localScale = new Vector2(-1, 1);
                }
                StartCoroutine(BillDamage());
            }
            if (distToPlayer > dist_to_player && WALL == false)
            {
                fight = false;
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
            if (death == true || WALL == true)
            {
                physik.velocity = new Vector2(0, 0);
                fight = true;
            }
        }
        if (hp >= HP&&death==false)
        {
            death = true;
            stop = true;
            Die();
        }
    }
    private bool WALL;
    private float zomb_wall_pos;
    private wall script_w;
    private bill bill;
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == "wall(Clone)" || other.name == "boom(Clone)")
        {
            WALL = true;
            zomb_wall_pos = transform.position.x - player.transform.position.x;
            StartCoroutine(WallDamage(other.gameObject));

        }
        if (other.name == "Bill"&&death==false)
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
    IEnumerator WallDamage(GameObject w)
    {
        script_w = w.gameObject.GetComponent<wall>();
        while (WALL == true)
        {
            yield return new WaitForSeconds(0.4f);
            physik.velocity = new Vector2(kef*speed * 7, 0f);
            yield return new WaitForSeconds(0.125f);
            physik.velocity = new Vector2(0, 0f);
            yield return new WaitForSeconds(0.75f);
            if (zomb_wall_pos >= 0 || script_w.hp <= 0)
                WALL = false;
        }
    }
    IEnumerator BillDamage()
    {
        yield return new WaitForSeconds(0.4f);
        physik.velocity = new Vector2(kef * speed * 8, 0f);
        yield return new WaitForSeconds(0.225f);
        physik.velocity = new Vector2(0, 0f);
        anim.SetBool("fight", false) ;
        anim.SetBool("stop", true);
        yield return new WaitForSeconds(4);
        if(death==false)
            stop = false;
        anim.SetBool("stop", false);
    }
    void Die()
    {
        physik.velocity = new Vector2(0, 0);
        shield.SetActive(false);
        Instantiate(money, money_spawn.position, transform.rotation);
        zombie_damage = 0;

    }
}
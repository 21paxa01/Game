using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bibo  : MonoBehaviour
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
    private shield_for_bill shield_scr;
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
        shield_scr = player.GetComponent<shield_for_bill>();
    }
    public float dist_to_player;
    void Update()
    {
        if (debaff.fire == true)
        {
            speed = default_speed;
            sprite.color = new Color(1f, 0f, 0f, 1f);
        }
        else if (debaff.freeze == true)
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
        distToPlayer = Vector2.Distance(transform.position+new Vector3(dist,0f,0f), player.transform.position);
        if (distToPlayer <= dist_to_player)
        {
            physik.velocity = new Vector2(0, 0);
            fight = true;
            dam = 0;
            if (test == 100f)
            {
                at_time = atack_time;
                damage = StartCoroutine(BillDamage());
            }


        }
        if (distToPlayer > dist_to_player && WALL == false)
        {
            fight = false;
        }
        anim.SetBool("fight", fight);


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
        if (death == true)
        {
            physik.velocity = new Vector2(0, 0);

            if (distToPlayer <= dist_to_player)
                poison.pois = true;
            else
                poison.pois = false;
        }
        if (WALL == true)
        {
            physik.velocity = new Vector2(0, 0);
            fight = true;
        }
        if (hp >= HP&&death==false)
        {
            death = true;
            Die();
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
            StartCoroutine(WallDamage(other.gameObject));
        }
        if (other.name == "Bill" && death == false)
        {
            if (player.transform.position.x > transform.position.x)
                bill.kef = 1;
            else
                bill.kef = -1;
            if (bill.invulnerability == false)
            {
                bill.discard();
                if (shield_scr.HP > 0)
                    shield_scr.HP -= zombie_damage;
                else
                    bill.HP -= zombie_damage;
                shield_scr.start_reg();
            }
        }
    }
    private int dam = 0;
    public float test = 100f;
    IEnumerator BillDamage()
    {
        while (dam == 0 && death == false)
        {

            at_time = 0f;
            if (distToPlayer <= dist_to_player)
            {
                test -= zombie_damage;
                if (player.transform.position.x > transform.position.x)
                    bill.kef = 1;
                else
                    bill.kef = -1;
                if (bill.invulnerability == false)
                {
                    bill.discard();
                    if (shield_scr.HP > 0)
                        shield_scr.HP -= zombie_damage;
                    else
                        bill.HP -= zombie_damage;
                    shield_scr.start_reg();
                }
                yield return new WaitForSeconds(atack_time);

            }
            else
            {
                dam = 1;
                test = 100f;
            }

        }
    }
    IEnumerator WallDamage(GameObject w)
    {
        script_w = w.gameObject.GetComponent<wall>();
        while (WALL == true)
        {
            if (zomb_wall_pos >= 0)
            {
                yield return new WaitForSeconds(atack_time);
                script_w.hp -= zombie_damage;
                if (zomb_wall_pos < 0 || script_w.hp <= 0)
                    WALL = false;
            }
            if (zomb_wall_pos < 0)
            {
                yield return new WaitForSeconds(atack_time);
                script_w.hp -= zombie_damage;
                if (zomb_wall_pos >= 0 || script_w.hp <= 0)
                    WALL = false;
            }

        }
    }
    private float dist=0f;
    void Die()
    {

        if (player.transform.position.x > transform.position.x)
            dist = -0.38f;
        else
            dist = 0.38f;
        Instantiate(money, money_spawn.position, transform.rotation);
        zombie_damage = 0;

    }




}
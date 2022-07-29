using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class giovanni: MonoBehaviour
{
    private Rigidbody2D physik;
    public GameObject player;
    public Animator anim;
    public bool fight;
    public bool death;
    public float zombie_damage;
    private float zomb_damage;
    public float heal_time;
    private float at_time = 0f;
    public float distToPlayer;
    public zombie_debaffs debaff;
    Coroutine damage;

    public SpriteRenderer sprite;
    public GameObject money;
    public Transform money_spawn;
    public GameObject zombie_hp;
    private zombie_hp script;

    public float default_speed;
    private float speed;
    public float HP;
    private float hp = 0;
    private bill bill;
    private shield_for_bill shield_scr;
    private bool heal;
    private bool stop;
    public GameObject coll_obj;
    private Collider2D coll;
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
        coll = coll_obj.GetComponent<Collider2D>();
        StartCoroutine(Heal());
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
        distToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (distToPlayer <= dist_to_player && script.stop == false)
        {
            physik.velocity = new Vector2(0, 0);
            stop = true;
        }
        else
            stop = false;
        if(heal==true)
            physik.velocity = new Vector2(0, 0);
        anim.SetBool("heal", heal);
        anim.SetBool("stop", stop);

        if (script.stop == false&&heal==false)
        {
            if (player.transform.position.x < transform.position.x + 0.1f && distToPlayer > dist_to_player && death == false)
            {
                physik.velocity = new Vector2(-speed, 0);
                transform.localScale = new Vector2(-1, 1);
            }
            if (player.transform.position.x > transform.position.x - 0.1f && distToPlayer > dist_to_player && death == false)
            {
                physik.velocity = new Vector2(+speed, 0);
                transform.localScale = new Vector2(1, 1);
            }
        }
        if (death == true || WALL == true)
        {
            physik.velocity = new Vector2(0, 0);
        }
        if (hp >= HP && death == false)
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
        if (other.name == "Bill" && death == false&&heal==false)
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
    IEnumerator Heal()
    {
        while (death == false)
        {
            heal = false;
            coll.enabled = false;
            yield return new WaitForSeconds(heal_time);
            coll.enabled = true; 
            heal = true;
            yield return new WaitForSeconds(2.25f);

        }
    }
    void Die()
    {
        StopCoroutine(Heal());
        Instantiate(money, money_spawn.position, transform.rotation);
        zombie_damage = 0;

    }




}
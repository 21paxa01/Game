using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lara : MonoBehaviour
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
    public float distToPlayer;
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
    }
    public float dist_to_player;
    void Update()
    {
        if (debaff.freeze == true)
        {
            speed = default_speed / 2;
            sprite.color = new Color(0f, 0f, 0f, 1f);
        }
        else
        {
            speed = default_speed;
            sprite.color = new Color(70f, 105f, 255f, 1f);
        }

        hp = script.hp;
        distToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (distToPlayer <= dist_to_player)
        {
            physik.velocity = new Vector2(0, 0);
            fight = true;


        }
        if (distToPlayer > dist_to_player && WALL == false)
        {
            fight = false;
        }
        anim.SetBool("fight", fight);


        if (player.transform.position.x < transform.position.x && distToPlayer > dist_to_player && death == false)
        {
            physik.velocity = new Vector2(-speed, 0);
        }
        if (player.transform.position.x > transform.position.x && distToPlayer > dist_to_player && death == false)
        {
            physik.velocity = new Vector2(+speed, 0);
        }
        if (player.transform.position.x < transform.position.x  && death == false)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        if (player.transform.position.x > transform.position.x  && death == false)
        {
            transform.localScale = new Vector2(1, 1);
        }
        if (death == true || WALL == true)
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

        }
    }
    void Die()
    {
        Instantiate(money, money_spawn.position, transform.rotation);

    }




}
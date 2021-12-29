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


    public GameObject money;
    public Transform money_spawn;

    public GameObject zombie_hp;
    private zombie_hp script;


    public float speed;
    public float HP;
    private float hp = 0;
    void Start()
    {
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
        if (hp == HP)
        {
            HP--;
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
    }
    private int dam = 0;
    public float test = 100f;
    IEnumerator BillDamage()
    {
        while (dam == 0)
        {

            at_time = 0f;
            if (distToPlayer <= dist_to_player)
            {
                bill.HP -= zombie_damage;
                test -= zombie_damage;
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
        death = true;
        Instantiate(money, money_spawn.position, transform.rotation);
        zombie_damage = 0;

    }




}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boss : MonoBehaviour
{
    private Rigidbody2D physik;
    public GameObject player;
    public Animator anim;
    public bool fight;
    public bool death;
    public bool stop = false;
    public float zombie_damage;
    private float zomb_damage;
    public float atack_time;
    public float distToPlayer;
    public zombie_debaffs debaff;
    private int kef;
    public GameObject money;
    public Transform money_spawn;
    public GameObject zombie_hp;
    private zombie_hp script;
    public GameObject attack_effekt;

    public SpriteRenderer sprite;
    public float default_speed;
    public float speed;
    public float HP;
    private int b_kef;
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
                if (player.transform.position.x > transform.position.x)
                {
                    kef = 1;
                    transform.localScale = new Vector2(0.8f, 0.8f);
                }
                else
                {
                    kef = -1;
                    transform.localScale = new Vector2(-0.8f, 0.8f);
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
                transform.localScale = new Vector2(-0.8f, 0.8f);
            }
            if (player.transform.position.x > transform.position.x && distToPlayer > dist_to_player && death == false)
            {
                physik.velocity = new Vector2(+speed, 0);
                transform.localScale = new Vector2(0.8f, 0.8f);
            }
            if (death == true || WALL == true)
            {
                physik.velocity = new Vector2(0, 0);
                fight = true;
            }
        }
        if (hp >= HP && death == false)
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
        if (other.name == "Bill" && death == false)
        {
            if (player.transform.position.x > transform.position.x)
                bill.kef = b_kef;
            else
                bill.kef = -b_kef;
            bill.discard();
            bill.HP -= zombie_damage;
        }
    }
    IEnumerator WallDamage(GameObject w)
    {
        script_w = w.gameObject.GetComponent<wall>();
        while (WALL == true)
        {
            yield return new WaitForSeconds(0.4f);
            physik.velocity = new Vector2(kef * speed * 7, 0f);
            yield return new WaitForSeconds(0.125f);
            physik.velocity = new Vector2(0, 0f);
            yield return new WaitForSeconds(0.75f);
            if (zomb_wall_pos >= 0 || script_w.hp <= 0)
                WALL = false;
        }
    }
    private int i=2;
    IEnumerator BillDamage()
    {
        while (stop == true)
        {
            i = Random.Range(1, 3);
            if (i == 1)
            {
                anim.SetBool("fight", fight);
                yield return new WaitForSeconds(1.1f);
                anim.SetBool("fight", false);
                anim.SetBool("stop", true);
                zombie_damage = 15f;
                b_kef = 6;
                physik.velocity = new Vector2(kef * speed * 8, 0f);
                yield return new WaitForSeconds(0.25f);
                anim.SetBool("fight", false);
                anim.SetBool("stop", true);
                b_kef = 3;
                zombie_damage = 5f;
                physik.velocity = new Vector2(0, 0f);
                yield return new WaitForSeconds(4);
                if (death == false && distToPlayer > dist_to_player)
                {
                    stop = false;
                    anim.SetBool("stop", false);
                }

            }
            if (i == 2)
            {
                b_kef = 3;
                anim.SetBool("fight_2", fight);
                yield return new WaitForSeconds(0.4f);
                b_kef = 6;
                zombie_damage = 8f;
                physik.velocity = new Vector2(kef * speed * 4, 0f);
                yield return new WaitForSeconds(0.15f);
                attack_effekt.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                attack_effekt.SetActive(false);
                b_kef = 3;
                zombie_damage = 5f;
                physik.velocity = new Vector2(kef * -speed * 3, 0f);
                yield return new WaitForSeconds(0.10f);
                anim.SetBool("fight_2", false);
                physik.velocity = new Vector2(0, 0f);
                if (death == false && distToPlayer > dist_to_player)
                {
                    stop = false; 
                }
            }
        }
    }
    void Die()
    {
        physik.velocity = new Vector2(0, 0);
        wave_img.victory = true;
        Instantiate(money, money_spawn.position, transform.rotation);
        zombie_damage = 0;

    }
}
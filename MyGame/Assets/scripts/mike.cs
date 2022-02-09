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
        anim = GetComponent<Animator>();
        player = GameObject.Find("Bill");
        zomb_damage = zombie_damage;
        script = zombie_hp.gameObject.GetComponent<zombie_hp>();
        HP = script.HP;
    }
    public float dist_to_player;
    void Update()
    {

        hp = script.hp;
        distToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (stop == false)
        {
            if (distToPlayer <= dist_to_player)
            {
                physik.velocity = new Vector2(0, 0);
                fight = true;
                dam = 0;
                if (test == 100f)
                {
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
            if (death == true || WALL == true)
            {
                physik.velocity = new Vector2(0, 0);
                fight = true;
            }
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
    IEnumerator WallDamage(GameObject w)
    {
        script_w = w.gameObject.GetComponent<wall>();
        while (WALL == true)
        {
            yield return new WaitForSeconds(0.4f);
            if (player.transform.position.x > transform.position.x)
                physik.velocity = new Vector2(speed * 7, 0f);
            else
                physik.velocity = new Vector2(-speed * 7, 0f);
            yield return new WaitForSeconds(0.125f);
            physik.velocity = new Vector2(0, 0f);
            yield return new WaitForSeconds(0.75f);
            if (zomb_wall_pos >= 0 || script_w.hp <= 0)
                WALL = false;
        }
    }
    IEnumerator BillDamage()
    {
        while (dam == 0)
        {
            if (distToPlayer <= dist_to_player)
            {
                yield return new WaitForSeconds(0.4f);
                if (player.transform.position.x > transform.position.x)
                    physik.velocity = new Vector2(speed*7, 0f);
                else
                    physik.velocity = new Vector2(-speed*7, 0f);
                yield return new WaitForSeconds(0.1f);
                stop = true;
                fight = false;
                physik.velocity = new Vector2(0, 0f);
                yield return new WaitForSeconds(4f);
                stop = false;

            }
            else if(stop==false)
            {
                dam = 1;
                test = 100f;
            }

        }
    }
    void Die()
    {

        death = true;
        Instantiate(money, money_spawn.position, transform.rotation);
        zombie_damage = 0;

    }




}
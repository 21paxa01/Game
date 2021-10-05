using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zombie : MonoBehaviour
{
    private Rigidbody2D physik;
    public GameObject player;
    public Animator anim;
    public bool fight ;
    public bool death;
    public float zombie_damage;
    private float zomb_damage;
    public float atack_time;
    private float at_time = 0f;
    private float distToPlayer;
    Coroutine damage;


   public GameObject money;
    public Transform money_spawn;


    public float speed;
    void Start()
    {
        physik = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        zomb_damage = zombie_damage;
    }
    public float dist_to_player;
    void Update()
    {

        distToPlayer = Vector2.Distance(transform.position, player.transform.position);
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
        else
        {
            fight = false;
        }
        anim.SetBool("fight", fight);


        if (player.transform.position.x < transform.position.x && distToPlayer>dist_to_player&&death==false)
        {
            physik.velocity = new Vector2(-speed,0);
            transform.localScale = new Vector2(-1, 1);
        }
        if (player.transform.position.x > transform.position.x&&distToPlayer>dist_to_player&&death==false)
        {
            physik.velocity = new Vector2(+speed, 0);
            transform.localScale = new Vector2(1, 1);
        }
        if (death == true)
        {
            physik.velocity = new Vector2(0, 0);
        }
    }
    public int HP;
    private int hp = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "pistol_bullet(Clone)"&&death==false)
        {
            hp += 1;
            Destroy(other.gameObject);
            if (hp >= HP)
            {
                death = true;
                Instantiate(money, money_spawn.position, transform.rotation);
                zombie_damage = 0;

            }
        }
        else if (other.name == "ak47_bullet(Clone)" && death == false)
        {
            hp += 1;
            Destroy(other.gameObject);
            if (hp >= HP)
            {
                death = true;
                zombie_damage = 0;
                Instantiate(money, money_spawn.position, transform.rotation);

            }
        }
        else if (other.name == "awp_bullet(Clone)" && death == false)
        {
            hp += 2;
            Destroy(other.gameObject);
            if (hp >= HP)
            {
                death = true;
                zombie_damage = 0;
                Instantiate(money, money_spawn.position, transform.rotation);

            }
        }
    }
    private int dam=0;
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
                dam= 1;
                test = 100f;
            }

        }
    }
    void Damage()
    {
        bill.HP -= zombie_damage;
        zombie_damage = 0f;
    }
    
    


}
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
    public float atack_time;
    private float distToPlayer;

   // public GameObject money;



    public float speed;
    void Start()
    {
        physik = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    public float dist_to_player;
    void Update()
    {

        distToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (distToPlayer <= dist_to_player)
        {
            physik.velocity = new Vector2(0, 0);
            fight = true;
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
            if (hp == HP)
            {
                death = true;
                //Instantiate(money, transform.position, transform.rotation);

            }
        }
        else if (other.name == "ak47_bullet(Clone)" && death == false)
        {
            hp += 1;
            Destroy(other.gameObject);
            if (hp == HP)
            {
                death = true;
                //Instantiate(money, transform.position, transform.rotation);

            }
        }
    }
    
    


}
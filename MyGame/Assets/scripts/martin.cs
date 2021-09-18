using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class martin : MonoBehaviour
{
    private Rigidbody2D physik;
    public GameObject player;

    public bool fight;
    public bool death;
    public static float zombie_damage=10f;
    
    private float distToPlayer;
    public static bool Death;
    Coroutine damage;


    public GameObject money;
    public Transform money_spawn;


    public float speed;
    void Start()
    {
        physik = GetComponent<Rigidbody2D>();
        
    }
    public float dist_to_player;
    void Update()
    {

        distToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (distToPlayer <= dist_to_player)
        {
            physik.velocity = new Vector2(0, 0);
            if (test == 100f)
            {
               
                Death = true;
            }


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
        if (death == true)
        {
            physik.velocity = new Vector2(0, 0);
        }
    }
    public int HP;
    private int hp = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "pistol_bullet(Clone)" && death == false)
        {
            hp += 1;
            Destroy(other.gameObject);
            death = true;
            Instantiate(money, money_spawn.position, transform.rotation);
            if (hp == HP)
            {
                physik.constraints = RigidbodyConstraints2D.FreezePositionX;
                physik.velocity = new Vector2(0, 0);
                Instantiate(money, money_spawn.position, transform.rotation);
                zombie_damage = 0;

            }
        }
        else if (other.name == "ak47_bullet(Clone)" && death == false)
        {
            hp += 1;
            
            death = true;
            Instantiate(money, money_spawn.position, transform.rotation);
            Destroy(other.gameObject);
            if (hp == HP)
            {
                
                physik.velocity = new Vector2(0, 0);
                //zombie_damage = 0;
                Instantiate(money, money_spawn.position, transform.rotation);

            }
        }
    }
    public float test = 100f;
   
    




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bird : MonoBehaviour
{
    private Rigidbody2D physik;
    public GameObject player;
    public Animator anim;
    public bool fight;
    public bool death;
    public float bird_damage;
    public float atack_time;
    public float distToPlayer;
    private int kef;
    private bool stop=false;
    public zombie_debaffs debaff;
    public GameObject money;
    public Transform money_spawn;
    private zombie_hp script;

    public SpriteRenderer sprite;
    public float default_speed;
    public float speed;
    public float HP;
    private float hp = 0;
    private float kef_x;
    private float kef_y;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        debaff = GetComponent<zombie_debaffs>();
        physik = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Bill");
        anim = GetComponent<Animator>();
        script = GetComponent<zombie_hp>();
        HP = script.HP;
        //if (transform.position.y <0f)
           // StartCoroutine(UP());
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
        if (player.transform.position.x > transform.position.x)
            kef = -1;
        else
            kef = 1;
        distToPlayer = Vector2.Distance(transform.position, player.transform.position);
        kef_x = Mathf.Abs(transform.position.x - player.transform.position.x);
        kef_y = transform.position.y - (player.transform.position.y+0.30f);
        if (stop == false)
        {
            hp = script.hp;
            if (player.transform.position.x < transform.position.x && death == false)
            {
                physik.velocity = new Vector2(-speed, 0);
                transform.localScale = new Vector2(1, 1);
            }
            else if (player.transform.position.x > transform.position.x && death == false)
            {
                physik.velocity = new Vector2(+speed, 0);
                transform.localScale = new Vector2(-1, 1);
            }
            if (player.transform.position.x < transform.position.x && death == false && player.transform.position.y + 0.30f < transform.position.y&&kef_x<=4f)
            {
                physik.velocity = new Vector2(-speed, (-speed) / (kef_x / kef_y));
                transform.localScale = new Vector2(1, 1);
            }
            else if (player.transform.position.x > transform.position.x && death == false && player.transform.position.y + 0.30f < transform.position.y&&kef_x<=4f)
            {
                physik.velocity = new Vector2(+speed, (-speed)/(kef_x/kef_y) );
                transform.localScale = new Vector2(-1, 1);
            }
            if (death == true || WALL == true)
            {
                physik.velocity = new Vector2(0, 0);
                fight = true;
            }
            if (hp >= HP&& death==false)
            {
                death = true;
                Die();
            }
        }
    }
    private bool WALL;
    private float zomb_wall_pos;
    private wall script_w;
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == "Bill")
        {
            bill.HP -= bird_damage;
            discard();
        }
    }
    private int dam = 0;
    public float test = 100f;
    IEnumerator WallDamage(GameObject w)
    {
        script_w = w.gameObject.GetComponent<wall>();
        while (WALL == true)
        {
            if (zomb_wall_pos >= 0)
            {
                yield return new WaitForSeconds(atack_time);
                script_w.hp -= bird_damage;
                if (zomb_wall_pos < 0 || script_w.hp <= 0)
                    WALL = false;
            }
            if (zomb_wall_pos < 0)
            {
                yield return new WaitForSeconds(atack_time);
                script_w.hp -= bird_damage;
                if (zomb_wall_pos >= 0 || script_w.hp <= 0)
                    WALL = false;
            }

        }
    }
    void Die()
    {
        Instantiate(money, money_spawn.position, transform.rotation);
        bird_spawn.bird_kol--;
        bird_damage = 0;

    }
    IEnumerator Discard()
    {
        stop = true;
        physik.velocity = new Vector2(kef * speed , speed);
        yield return new WaitForSeconds(0.2f);
        stop = false;
    }
    public void discard()
    {
        StartCoroutine(Discard());
    }
    IEnumerator UP()
    {
        while (death == false)
        {
            stop = true;
            physik.velocity = new Vector2(-5*speed*kef, 5*speed);
            yield return new WaitForSeconds(0.1f);
            stop = false;
            yield return new WaitForSeconds(0.7f);
        }
    }

}
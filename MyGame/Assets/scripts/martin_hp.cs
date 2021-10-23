using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class martin_hp : MonoBehaviour
{
    public Image bar;
    public Image back;
    public float fill;
    private float distToPlayer;
    public GameObject player;

    public Animator anim;
    public float death_time;
    public bool death;
    public float dist_to_player;
    public float boom_radius;

    public GameObject money;
    public Transform money_spawn;
    private bool wall;

    void Start()
    {
        fill = 1f;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        distToPlayer = Vector2.Distance(transform.position, player.transform.position);
        bar.fillAmount = fill;
        if(distToPlayer<=dist_to_player )
            StartCoroutine(Die());
    }
    public float HP;
    private float hp = 0;
    public bool dam_to_bill = false;
    IEnumerator Die()
    {
        death = true;
        anim.SetBool("death", death);
        Destroy(back);
        yield return new WaitForSeconds(death_time);
        Instantiate(money, money_spawn.position, transform.rotation);
        if (distToPlayer <= boom_radius)
            dam_to_bill = true;
        if(dam_to_bill == true)
        {
            bill.HP -= martin.zombie_damage;
        }
        Destroy(gameObject);
        hp = 0;
    }
    private wall script_w;
    IEnumerator WALL_Die(GameObject w)
    {
        script_w = w.gameObject.GetComponent<wall>();
        death = true;
        anim.SetBool("death", death);
        Destroy(back);
        yield return new WaitForSeconds(death_time);
        Instantiate(money, money_spawn.position, transform.rotation);
        script_w.hp -= martin.zombie_damage;
        if (distToPlayer <= boom_radius)
            dam_to_bill = true;
        if (dam_to_bill == true)
        {
            bill.HP -= martin.zombie_damage;
        }
        Destroy(gameObject);
        hp = 0;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "pistol_bullet(Clone)" && death == false)
        {
            hp += 1;
            fill = 1 - hp / HP;
            Destroy(other.gameObject);
            if (hp >= HP)
            {
                StartCoroutine(Die());
            }
        }
        else if (other.name == "ak47_bullet(Clone)" && death == false)
        {
            hp += 1;
            fill = 1 - hp / HP;
            Destroy(other.gameObject);
            if (hp >= HP)
            {
                StartCoroutine(Die());
            }
        }
        else if (other.name == "awp_bullet(Clone)" && death == false)
        {
            hp += 1;
            fill = 1 - hp / HP;
            Destroy(other.gameObject);
            if (hp >= HP)
            {
                StartCoroutine(Die());
            }
        }
        if (other.name == "wall(Clone)" || other.name == "boom(Clone)")
        {
            wall = true;
            hp += 1;
            fill = 1 - hp / HP;
            if (hp >= HP)
            {
                StartCoroutine(WALL_Die(other.gameObject));
            }
        }

    }
}
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

    // Start is called before the first frame update
    void Start()
    {
        fill = 1f;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
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
        if (distToPlayer <= boom_radius)
            dam_to_bill = true;
        if(dam_to_bill == true)
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
       
    }
}
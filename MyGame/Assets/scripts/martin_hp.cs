using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class martin_hp : MonoBehaviour
{
    public Image bar;
    public Image back;
    public float fill;

    public Animator anim;
    public float death_time;
    public bool death;

    // Start is called before the first frame update
    void Start()
    {
        fill = 1f;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = fill;
        if(martin.Death==true)
            StartCoroutine(Die());
    }
    public float HP;
    private float hp = 0;
    public bool dam_to_bill = false;
    IEnumerator Die()
    {
        death = true;
        anim.SetBool("death", death);
        dam_to_bill = true;
        Destroy(back);
        yield return new WaitForSeconds(death_time);
        if(dam_to_bill == true)
        {
            bill.HP -= martin.zombie_damage;
            martin.zombie_damage = 0f;
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
        if (other.name == "Bill")
        {
            dam_to_bill = true;
        }
    }
}
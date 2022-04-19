using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zombie_hp : MonoBehaviour
{
    public Image bar;
    public Image back;
    public float fill;

    public Animator anim;
    public float death_time;
    public bool death;
    public SpriteRenderer sp;

    void Start()
    {
        fill = 1f;
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        bar.fillAmount = fill;
        if (hp >= HP&&death==false)
        {
            death = true;
            StartCoroutine(Die());
        }
    }
    public float HP;
    public float hp = 0;
    IEnumerator Die()
    {
        sp.sortingOrder = 8;
        spawn.zombie_kol--;
        anim.SetBool("death", death);
        Destroy(back);
        yield return new WaitForSeconds(death_time);
        Destroy(gameObject);
        hp = 0;
    }
}
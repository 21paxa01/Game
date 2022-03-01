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

    void Start()
    {
        fill = 1f;
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        bar.fillAmount = fill;
        if (hp == HP)
        {
            HP--;
            StartCoroutine(Die());
        }
    }
    public float HP;
    public float hp = 0;
    IEnumerator Die()
    {
        death = true;
        spawn.zombie_kol--;
        anim.SetBool("death", death);
        Destroy(back);
        yield return new WaitForSeconds(death_time);
        Destroy(gameObject);
        hp = 0;
    }
}

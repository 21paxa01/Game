using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zombie_hp : MonoBehaviour
{
    public Image bar;
    public Image back;
    public float fill;
    public bool stop;

    public Animator anim;
    public float death_time;
    public bool death;
    public SpriteRenderer sp;
    public Rigidbody2D rb;
    public Save save_script;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fill = 1f;
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        save_script = GameObject.Find("save").GetComponent<Save>();
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
        save_script.save_killed_zombies++;
        save_script.Save_task();
        anim.SetBool("death", death);
        Destroy(back);
        yield return new WaitForSeconds(death_time);
        Destroy(gameObject);
        hp = 0;
    }
    public int kef;
    public float disc_time;
    IEnumerator Discard()
    {
        stop = true;
        rb.velocity = new Vector2(kef * 1, 0f);
        yield return new WaitForSeconds(disc_time);
        stop = false;
    }
    public void discard()
    {
        StartCoroutine(Discard());
    }
}
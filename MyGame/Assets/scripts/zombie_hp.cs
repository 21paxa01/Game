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
    }
    public float HP;
    private float hp = 0;
    IEnumerator Die()
    {
        death = true;
        anim.SetBool("death", death);
        Destroy(back);
        yield return new WaitForSeconds(death_time);
        Destroy(gameObject);
        hp = 0;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "pistol_bullet(Clone)"&&death==false)
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

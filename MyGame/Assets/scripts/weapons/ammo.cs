using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo : MonoBehaviour
{
    public float speed;
    public float destroyTime;
    public float death_time;
    public bool death;
    public Animator anim;
    private Rigidbody2D rb;
    private zombie_hp script;
    public float ammo_damage;
    public float default_damage;
    public bool road;
    public float test;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Invoke("DestroyAmmo", destroyTime);
        
    }


    void Update()
    {
        test = transform.position.x;
        if (death == false)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
        {
            rb.velocity = new Vector2(0f, 0f);
            rb.gravityScale = 0f;
        }
    }

    void DestroyAmmo()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "room")
        {
            if (road == true)
            {
                ammo_damage = 0f;
                StartCoroutine(Die());
            }
        }
        if(other.name == "wall(Clone)" || other.name == "Shield")
        {
            ammo_damage = 0f;
            StartCoroutine(Die());
        }
        if (other.CompareTag("zombie"))
        {
            script = other.gameObject.GetComponent<zombie_hp>();
            if (script.death == false)
            {
                StartCoroutine(Die());
                if (script.hp + ammo_damage > script.HP)
                {
                    script.hp = script.HP;
                }
                else
                    script.hp += ammo_damage;
                script.fill = 1 - script.hp / script.HP;
            }
        }
    }
    IEnumerator Die()
    {
        death = true;
        anim.SetBool("die", true);
        transform.localScale = new Vector3(1f, 1f, 1f);
        yield return new WaitForSeconds(death_time);
        Destroy(gameObject);
    }

}

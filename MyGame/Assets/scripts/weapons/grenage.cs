using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenage : MonoBehaviour
{
    public Animator anim;
    private bool death;
    public float speed;
    public float death_time;
    private Rigidbody2D rb;
    private zombie_hp script;
    public float damage;
    private Collider2D coll;
    public float reload_time;
    private SpriteRenderer sprite;
   void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (death == false)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
        {
            rb.velocity = new Vector2(0f, 0f);
            rb.gravityScale = 0f;
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "room" || other.name == "wall(Clone)" || other.name == "Shield")
        {
            if (death == false)
            {
                StartCoroutine(Die());
                StartCoroutine(Camera_boom());
            }
        }
        if (other.CompareTag("zombie"))
        {
            if (death == false)
            {
                StartCoroutine(Die());
                StartCoroutine(Camera_boom());
            }
                script = other.gameObject.GetComponent<zombie_hp>();
            if (script.death == false)
            {
                if (script.hp + damage > script.HP)
                {
                    script.hp = script.HP;
                }
                else
                    script.hp += damage;
                script.fill = 1 - script.hp / script.HP;
            }
        }
    }
    IEnumerator Die()
    {
        death = true;
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        anim.SetBool("boom", true);
        yield return new WaitForSeconds(death_time);
        sprite.color = new Color(1f, 1f, 1f, 0f);
        damage = 0f;

    }
    IEnumerator Camera_boom()
    {
        for (int i = 0; i < 10; i++)
        {
            if (i % 2 == 0)
                ShopCamera.x = -0.15f;
            else
                ShopCamera.x = 0.15f;
            yield return new WaitForSeconds(0.05f);
        }
        ShopCamera.x = 0;
        Destroy(gameObject);
    }
}

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
    public GameObject line;
    private SpriteRenderer sprite;
    public float rotate_distance;
    private float rotate_y;
    private float rotate_z;
    private float kef;
    public bool zomb_trig;
    public bool camera_boom;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
        rotate_z = 45f;
        if(transform.rotation.z>0.5f)
            rotate_z = 135f;
        //StartCoroutine(Rotate());
        //StartCoroutine(Line());
    }

    void Update()
    {
        //Instantiate(line, transform.position, Quaternion.Euler(0f, rotate_y, rotate_z));
        if (death == false)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
        {
            rb.velocity = new Vector2(0f, 0f);
            rb.gravityScale = 0f;
        }
        //rotate = transform.rotation.z;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "room" || other.name == "wall(Clone)" || other.name == "Shield")
        {
            if (death == false)
            {
                transform.position = new Vector3(transform.position.x, -3.082f, transform.position.z);
                StartCoroutine(Die());
                //StartCoroutine(Camera_boom());
            }
        }
        if (other.CompareTag("zombie")&&zomb_trig==true)
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
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        zomb_trig = true;
        StopCoroutine(Line());
        death = true;
        anim.SetBool("boom", true);
        yield return new WaitForSeconds(death_time);
        sprite.color = new Color(1f, 1f, 1f, 0f);
        damage = 0f;
        Destroy(gameObject);

    }
    IEnumerator Camera_boom()
    {
        for (int i = 0; i < 10; i++)
        {
            if (camera_boom == true)
            {
                if (i % 2 == 0)
                    ShopCamera.x = -0.15f;
                else
                    ShopCamera.x = 0.15f;
            }
            yield return new WaitForSeconds(0.05f);
        }
        ShopCamera.x = 0;
    }
    IEnumerator Line()
    {
        while (1 > 0)
        {
            Instantiate(line, transform.position, Quaternion.Euler(0f, rotate_y, rotate_z));
            yield return new WaitForSeconds(0.00001f);
        }
    }
    IEnumerator Rotate()
    {
        kef = 1f;
        rotate_y = 1f;
        if (rotate_z == 45f) {
            kef = -1f;
            rotate_y = -1f;
        }
        yield return new WaitForSeconds(0.1f);
        for(int i = 0; i < rotate_distance; i++)
        {
            transform.rotation = Quaternion.Euler(0f,rotate_y, rotate_z);
            rotate_z += kef;
            yield return new WaitForSeconds(0.002f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cake : MonoBehaviour
{
    public float speed;
    public float destroyTime;
    public Rigidbody2D rb;
    public float test;
    public float ost;
    public float rot;
    public float rotat;
    private int a = 0;
    public float damage;
    private wall script_w;
    public GameObject player;
    private bill bill;
    private shield_for_bill shield_scr;
    public Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (ost == -1)
            ost = -(1.5f / test);
        else
            ost = 1.5f / test;
        rot = 9f * ost;
        StartCoroutine(Rotation());
        player = GameObject.Find("Bill");
        bill = player.GetComponent<bill>();
        shield_scr = player.GetComponent<shield_for_bill>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        ost = 1.5f / test;
    }

    void DestroyAmmo()
    {
        Destroy(gameObject);
    }
    IEnumerator Rotation()
    {
        while (a == 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, rotat);
            rotat -= rot;
            yield return new WaitForSeconds(0.025f);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Bill")
        {
            anim.SetBool("boom", true);
            if (player.transform.position.x > transform.position.x)
                bill.kef = 1;
            else
                bill.kef = -1;
            if (bill.invulnerability == false)
            {
                bill.discard();
                if (shield_scr.HP > 0)
                    shield_scr.HP -= damage;
                else
                    bill.HP -= damage;
                shield_scr.start_reg();
            }
            Destroy(gameObject);
        }
        if (other.name == "wall(Clone)" || other.name == "boom(Clone)")
        {
            script_w = other.gameObject.GetComponent<wall>();
            script_w.hp -= damage;
            Destroy(gameObject);
        }
        if (other.name == "room")
        {
            anim.SetBool("boom", true);
            Invoke("DestroyAmmo", destroyTime);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightning : MonoBehaviour
{
    public float speed;
    public float destroyTime;
    public Rigidbody2D rb;
    public float damage;
    private wall script_w;
    public GameObject player;
    private bill bill;
    private shield_for_bill shield_scr;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Bill");
        bill = player.GetComponent<bill>();
        shield_scr = player.GetComponent<shield_for_bill>();
        Invoke("DestroyAmmo", destroyTime);
    }


    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        //rb.gravityScale = 2f*ost;
    }

    void DestroyAmmo()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Bill")
        {
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

    }
}

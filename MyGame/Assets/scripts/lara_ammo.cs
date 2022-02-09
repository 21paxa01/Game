using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lara_ammo : MonoBehaviour
{
    public float speed;
    public float destroyTime;
    public Rigidbody2D rb;
    public float test;
    public float ost;
    public float rot;
    public float rotat ;
    private int a = 0;
    public float damage;
    private wall script_w;
    void Start()
    {
        Invoke("DestroyAmmo", destroyTime);
        rb = GetComponent<Rigidbody2D>();
        if(ost==-1)
            ost = -(1.5f / test);
        else
            ost = 1.5f / test;
        rot = 9f * ost;
        StartCoroutine(Rotation());
    }


    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        ost = 1.5f / test;
        //rb.gravityScale = 2f*ost;
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
        if (other.name == "Bill" )
        {
            bill.HP -= damage;
            Destroy(gameObject);
        }
        if (other.name == "wall(Clone)" || other.name == "boom(Clone)")
        {
            Destroy(gameObject);
            script_w = other.gameObject.GetComponent<wall>();
            script_w.hp -= damage;
        }
        if (other.name == "room")
        {
            Destroy(gameObject);
        }

    }
}
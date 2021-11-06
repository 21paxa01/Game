using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boom : MonoBehaviour
{
    public float boom_time;
    public Collider2D coll;
    public GameObject BOOM;
    public  float test;
    private wall script;
    public float boom_damage;
    private zombie_hp script_w;
    void Start()
    {
        coll = GetComponent<Collider2D>();
        script = BOOM.gameObject.GetComponent<wall>();
    }


    void Update()
    {
       
        if (script.hp <= 0)
        {
            coll.enabled = true;
           
        }
    }
    IEnumerator Boom(GameObject zomb)
    {
        yield return new WaitForSeconds(0.5f);
        script_w = zomb.gameObject.GetComponent<zombie_hp>();
        if (script.HP > script.hp)
        {
            if (script_w.hp + boom_damage > script_w.HP)
                script_w.hp = script_w.HP;
            else
                script_w.hp+=boom_damage;
            script_w.fill = 1 - script_w.hp / script_w.HP;
        }        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (script.hp <= 0)
        {
            if (other.CompareTag("zombie"))
            {
                StartCoroutine(Boom(other.gameObject));
                test = 100;
            }
        }
    }
}
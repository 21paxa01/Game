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
    private bibo_hp script_w;
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
    void Boom(GameObject zomb)
    {
        script_w = zomb.gameObject.GetComponent<bibo_hp>();
        script_w.hp++;
        script_w.fill = 1 - script_w.hp / script_w.HP;
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "bibo_zombie(Clone)") {
            Boom(other.gameObject);
            test = 100;
        }
    }
}
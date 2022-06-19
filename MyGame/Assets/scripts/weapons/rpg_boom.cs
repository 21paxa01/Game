using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rpg_boom : MonoBehaviour
{
    public Collider2D coll;
    public ammo script;
    public GameObject rocket;
    void Start()
    {
        coll = GetComponent<Collider2D>();
        script = rocket.GetComponent<ammo>();
    }

    void Update()
    {
        if (script.death == true)
        {
            coll.enabled = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skin : MonoBehaviour
{
    private bill bill_scr;
    public GameObject bill;
    public Animator anim;
    private bool death;
    private bool onGround;
    private float moveX;
    void Start()
    {
        anim = GetComponent<Animator>();
        bill_scr = bill.GetComponent<bill>();
    }

    void Update()
    {
        onGround = bill_scr.onGround;
        anim.SetBool("onGround", onGround);
        moveX = bill_scr.moveX;
        anim.SetFloat("moveX", moveX);
        death = bill_scr.death;
        anim.SetBool("death", death);
    }
}

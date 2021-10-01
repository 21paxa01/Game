using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kettle : MonoBehaviour
{
    public Transform Bill;
    private float distToPlayer;
    public Animator anim;
    public float test;
    void Start()
    {
       anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distToPlayer = Vector2.Distance(transform.position, Bill.transform.position);
        test = distToPlayer;
        if(distToPlayer<0.3f)
            anim.SetBool("fire", true);
    }
}

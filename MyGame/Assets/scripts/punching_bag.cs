using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punching_bag : MonoBehaviour
{
    public Animator anim;
    public float distToPlayer;
    public Transform player;
    public bool move;
    public int test;
    private int a = 0;
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        distToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (test == 1 && distToPlayer > 0.81f)
            test = 0;
        if (test == 1)
            move = false;
        else if (distToPlayer < 0.8f)
            move = true;
        if (a == 0&&move==true)
        {
            a = 1;
            StartCoroutine(Move());
        }
        anim.SetBool("move", move);
    }
    IEnumerator Move()
    {
        yield return new WaitForSeconds(6f);
        test = 1;
        a = 0;
        move = false;
    }
}

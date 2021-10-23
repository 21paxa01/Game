using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    public int count;
    public  float hp ;
    public SpriteRenderer sp;
    public Animator anim;
    public Collider2D coll;
    private int a=0;
    public float death_time;
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    
    void Update()
    {
        /*if (Input.touchCount > 0 && rapt_menu.GameIsPaused == true)
        {
            Touch touchZero = Input.GetTouch(0);
            transform.position = new Vector2(touchZero.position.x, -3.0816f);
            if (Input.touchCount == 0)
                rapt_menu.GameIsPaused = false;
        }
        count = Input.touchCount;*/
        
        anim.SetFloat("hp", hp);
        if (hp <= 0 && a == 0)
        {
            a = 1;
            StartCoroutine(Die());
        }
    }
    IEnumerator Die()
    {
        coll.isTrigger = true;
        yield return new WaitForSeconds(death_time);
        Destroy(gameObject);
    }

}

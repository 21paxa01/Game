using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class luk : MonoBehaviour
{
    public SpriteRenderer sp;
    public GameObject bill;
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        bill = GameObject.Find("Bill");
    }

    
    void Update()
    {
     if (bill.transform.position.y > -3f)
            sp.sortingOrder = 4;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class luk : MonoBehaviour
{
    public SpriteRenderer sp;
    public Transform bill;
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
     if (bill.position.y > -3f)
            sp.sortingOrder = 4;
    }
}

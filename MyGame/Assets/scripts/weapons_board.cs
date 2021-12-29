using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapons_board : MonoBehaviour
{
    public SpriteRenderer sp;
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }
    public void Change()
    {
        if(sp.sortingOrder == 1)
            sp.sortingOrder = 21;
        else
            sp.sortingOrder = 1;
    }
}

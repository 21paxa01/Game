using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie_debaffs : MonoBehaviour
{
    public float freeze_time;
    public bool freeze;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    IEnumerator Freeze()
    {
        freeze = true;
        while (freeze_time > 0)
        {
            freeze_time -= 1f;
            yield return new WaitForSeconds(1f);
        }
        freeze = false;
    }
    public void start_freeze()
    {
        StartCoroutine(Freeze());
    }
}

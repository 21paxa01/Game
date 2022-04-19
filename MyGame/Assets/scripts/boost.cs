using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boost : MonoBehaviour
{
    public shoting script;
    private bool chek;
    public float boost_value;
    void Start()
    {
        chek = false;
        script = GetComponent<shoting>();
    }

    void Update()
    {
        if (script.shot == true && chek == false)
        {
            chek = true;
            StartCoroutine(BOOST());
        }
    }
    IEnumerator BOOST()
    {
        while (script.shot == true&&script.ReloaD==false)
        {
            yield return new WaitForSeconds(script.startTime);
            if (script.startTime - boost_value >= script.DefaultstartTime / 2)
                script.startTime -=boost_value;
        }
        chek = false;
        script.startTime = script.DefaultstartTime;
    }
}

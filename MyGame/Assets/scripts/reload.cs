using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reload : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private int i;
    // Update is called once per frame
    void Update()
    {
        if (shoting.ReloaD == true)
        {
            i = 1;
            StartCoroutine(Reload());
        }
    }
    IEnumerator Reload()
    {
        while (i > 0)
        {
            yield return new WaitForSeconds(shoting.ReloadTime);
            shoting.ReloaD = false;
            i = 0;
        }
    }
}

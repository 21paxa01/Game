/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reload : MonoBehaviour
{

    void Start()
    {
        
    }
    private int i;
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
*/
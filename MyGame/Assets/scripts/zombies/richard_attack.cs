using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class richard_attack : MonoBehaviour
{
    public Transform shotDir;
    public GameObject ammo;
    private gru script;
    int a = 1;
    public GameObject zombie;
    public bool test;
    public float ost;
    private lightning script_1;
    void Start()
    {
        script = zombie.gameObject.GetComponent<gru>();
        script_1 = ammo.gameObject.GetComponent<lightning>();
    }


    void Update()
    {
        if (script.fight == true && a == 1)
        {
            a = 0;
            StartCoroutine(Shot());
        }
    }
    IEnumerator Shot()
    {
        yield return new WaitForSeconds(0.5f);
        while (a == 0)
        {
            if (script.death == true)
            {
                a = 1;
                break;
            }
            if (zombie.transform.localScale.x == -1f)
            {
                shotDir.rotation=Quaternion.Euler(0f,180f,0f);
            }
            else
            {
                shotDir.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            Instantiate(ammo, shotDir.position, shotDir.rotation);
            if (script.fight == false)
            {
                a = 1;
                test = false;
            }
            yield return new WaitForSeconds(0.6f);
        }
    }
}

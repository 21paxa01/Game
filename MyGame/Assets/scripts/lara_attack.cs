using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lara_attack : MonoBehaviour
{
    public Transform shotDir;
    public GameObject ammo;
    private lara script;
    int a = 1;
    public GameObject zombie;
    public bool test;
    public float ost;
    private lara_ammo script_1;
    void Start()
    {
        script = zombie.gameObject.GetComponent<lara>();
        script_1=ammo.gameObject.GetComponent<lara_ammo>();
    }


    void Update()
    {
        if (script.fight == true && a == 1)
        {
            a = 0;
            StartCoroutine(Shot());
        }
        ost = script.distToPlayer;
        script_1.test = ost;
        if (zombie.transform.localScale.x == -1f)
        {
            shotDir.rotation = Quaternion.Euler(0f, 0f, 135f);
            script_1.rotat = 135f;
            script_1.ost =-1 ;
        }
        else
        {
            shotDir.rotation = Quaternion.Euler(0f, 0f, 45f);
            script_1.rotat = 45f;
            script_1.ost = 1;
        }
    }
    IEnumerator Shot()
    {
        yield return new WaitForSeconds(0.5f);
        while (a == 0) {
            if (script.death == true)
            {
                a = 1;
                break;
            }
            test = true;
            Instantiate(ammo, shotDir.position, shotDir.rotation);
            yield return new WaitForSeconds(1.66666667f);
            if (script.fight == false)
            {
                a = 1;
                test = false;
            }
        } 
    }
}

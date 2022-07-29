using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gru_attack : MonoBehaviour
{
    public Transform shotDir;
    public GameObject ammo;
    private gru script;
    int a = 1;
    public GameObject zombie;
    public bool test;
    public float ost;
    private Cake script_1;
    void Start()
    {
        script = zombie.gameObject.GetComponent<gru>();
        script_1 = ammo.gameObject.GetComponent<Cake>();
    }


    void Update()
    {
        if (script.fight == true && a == 1)
        {
            a = 0;
            StartCoroutine(Shot());
        }
        ost = script.distToPlayer;
        if (zombie.transform.localScale.x == -1f)
        {
            shotDir.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            shotDir.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
    IEnumerator Shot()
    {
        yield return new WaitForSeconds(0.4f);
        while (a == 0)
        {
            if (script.death == true)
            {
                a = 1;
                break;
            }
            test = true;
            script_1.test = ost;
            if (zombie.transform.localScale.x == -1f)
            {
                script_1.rotat = 135f;
                script_1.ost = -1;
            }
            else
            {
                script_1.rotat = 45f;
                script_1.ost = 1;
            }
            Instantiate(ammo, shotDir.position, shotDir.rotation);
            yield return new WaitForSeconds(0.5f);
            if (script.fight == false)
            {
                a = 1;
                test = false;
            }
        }
    }
}

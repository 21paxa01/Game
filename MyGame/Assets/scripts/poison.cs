using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class poison : MonoBehaviour
{
    public GameObject poison_icon;
    public float poison_damage;
    public int a;
    public static bool pois;
    public bool test;
    private bool debaff;
    public GameObject head;
    void Start()
    {
        poison_icon.SetActive(false);
    }

    void Update()
    {
        if (pois == true)
        {
            a = 10;
            if (debaff == false)
            {
                StartCoroutine(Poison());
                debaff = true;
            }
        }
        test = pois;
    }
    IEnumerator Poison()
    {
        while (a >= 0)
        {
            head.SetActive(true);
            poison_icon.SetActive(true);
            bill.HP -= poison_damage;
            yield return new WaitForSeconds(1f);
            a--;
        }
        debaff = false;
        head.SetActive(false);
        poison_icon.SetActive(false);
    }
}

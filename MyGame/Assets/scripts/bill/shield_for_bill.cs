using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shield_for_bill : MonoBehaviour
{
    public float hp;
    public float HP;
    public Image bar;
    private float fill;
    private bool regen;
    public float def_regen_time;
    public float regen_time;
    private LOUIS louis;
    public GameObject Louis;
    void Start()
    {
        HP = hp;
        //bar = GetComponent<Image>();
        regen_time = def_regen_time;
        louis = Louis.GetComponent<LOUIS>();
    }


    void Update()
    {
        if (HP <= 0)
        {
            HP = 0;
            louis.red=true;
        }
        else
        {
            louis.red = false;
        }
        if (HP > hp)
            HP = hp;
        fill = HP / hp;
        bar.fillAmount = fill;
    }
    IEnumerator Regenaration()
    {
        regen = true;
        while (HP < hp)
        {
            while (regen_time > 0)
            {
                yield return new WaitForSeconds(1f);
                regen_time -= 1f;
            }
            HP += 5;
            louis.red = false;
            regen_time = def_regen_time;
        }
        regen = false;
    }
    public void start_reg()
    {
        regen_time = def_regen_time;
        if(regen==false)
            StartCoroutine(Regenaration());
    }
}

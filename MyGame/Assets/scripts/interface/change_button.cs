using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class change_button : MonoBehaviour
{
    public GameObject bill;
    private change_weapon script;
    public int i;
    private shoting reload;
    void Start()
    {
        script = bill.GetComponent<change_weapon>();
    }

    void Update()
    {
        
    }
    public void Change()
    {
        if (script.reload[change_weapon.change] == true)
        {
            reload = script.weapons[change_weapon.change].GetComponent<shoting>();
            if (reload.ReloaD == false)
            {
                script.weapons[change_weapon.change].SetActive(false);
                script.now_weapon[change_weapon.change].SetActive(false);
                change_weapon.change = i;
                script.now_weapon[change_weapon.change].SetActive(true);
                script.weapons[change_weapon.change].SetActive(true);
            }
        }
        else
        {
            script.weapons[change_weapon.change].SetActive(false);
            script.now_weapon[change_weapon.change].SetActive(false);
            change_weapon.change = i;
            script.now_weapon[change_weapon.change].SetActive(true);
            script.weapons[change_weapon.change].SetActive(true);
        }
    }
}

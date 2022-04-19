using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class my_weapon : MonoBehaviour
{
    public GameObject weapon;
    public GameObject inventory;
    public Inventory script;
    public Image img;
    public int j;
    private int i;
    public GameObject bill;
    private change_weapon weap_script;
    private bill bill_scr;
    private shoting shot_scr;
    public int x;
    void Start()
    {
        x = -1;
        script = inventory.GetComponent<Inventory>();
        img = weapon.GetComponent<Image>();
        weap_script = bill.GetComponent<change_weapon>();
        bill_scr = bill.GetComponent<bill>();
    }

    void Update()
    {
        
    }
    public void Take_weapon()
    {
        i = j - 1;
        if (i == -1)
            i = 1;
        if ( script.now_weapon[i] != script.weapons_arr[script.i])
        {
            if (x >= 0)
            {
                weap_script.chek[x] = false;
            }
            script.now_weapon[j] = script.weapons_arr[script.i];
            img.sprite = script.img.sprite;
            weapon.SetActive(true);
            x = script.i;
            weap_script.chek[x] = true;
            change_weapon.change = x;
            bill_scr.weapon_chek = true;
        }
    }
}

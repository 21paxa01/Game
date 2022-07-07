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
    public GameObject stick;
    private stick stick_script;
    private shoting shot_scr;
    public int x;
    public GameObject change;
    public Image change_img;
    private change_button change_scr;
    void Start()
    {
        x = -1;
        script = inventory.GetComponent<Inventory>();
        img = weapon.GetComponent<Image>();
        weap_script = bill.GetComponent<change_weapon>();
        bill_scr = bill.GetComponent<bill>();
        change_img = change.GetComponent<Image>();
        change_scr = change.GetComponent<change_button>();
    }

    void Update()
    {
        
    }
    public void Take_weapon()
    {
        i = j - 1;
        if (i == -1)
            i = 1;
        if ( script.now_weapon[i] != script.i&&script.stop==false&&script.category_i==0)
        {
            if (x >= 0)
            {
                weap_script.chek[x] = false;
            }
            /*if(script.now_weapon[i]!=-1)
                weap_script.weapons[script.now_weapon[i]].SetActive(false);
            if (script.now_weapon[j] != -1)
                weap_script.weapons[script.now_weapon[j]].SetActive(false);
          */script.now_weapon[j] = script.i;
            img.sprite = script.img.sprite;
            change.SetActive(true);
            change_img.sprite = img.sprite;
            weapon.SetActive(true);
            x = script.i;
            weap_script.chek[x] = true;
            //weap_script.weapons[x].SetActive(true);
            /*if (x == 6)
            {
                stick = GameObject.Find("stick");
                stick_script = stick.GetComponent<stick>();
                stick_script.inventory = true;
                stick.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 90);
                stick.transform.position = new Vector3(bill.transform.position.x+0.1f, bill.transform.position.y+ 0.1452f, transform.position.z);
            }*/
            change_weapon.change = x;
            change_scr.i = x;
            change_weapon.k++;
            bill_scr.weapon_chek = true;
        }
    }
}

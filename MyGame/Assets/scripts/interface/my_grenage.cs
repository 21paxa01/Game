using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class my_grenage : MonoBehaviour
{
    public GameObject inventory;
    public Inventory script;
    private change_weapon change_script;
    public GameObject bill;
    public Image grenage;
    public GameObject grenage_img;
    public GameObject cell;
    private granade_cell cell_script;
    private grenage grenage_script;
    public Image sprite;
    void Start()
    {
        script = inventory.GetComponent<Inventory>();
        change_script = bill.GetComponent<change_weapon>();
        grenage = grenage_img.GetComponent<Image>();
        cell_script = cell.GetComponent<granade_cell>();
        sprite = cell.GetComponent<Image>();
    }

    void Update()
    {
        
    }
    public void Take_grenage()
    {
        if (change_script.g_chek[script.g_cell_ind_arr[script.i]] == false&&script.stop== false&&script.category_i == 3)
        {
            cell.SetActive(true);
            grenage_img.SetActive(true);
            grenage.sprite = script.img.sprite;
            change_script.g_chek[script.g_cell_ind_arr[script.i]] = true;
            cell_script.granade = change_script.grenages_arr[script.i];
            grenage_script = change_script.grenages_arr[script.i].GetComponent<grenage>();
            cell_script.reload_time = grenage_script.reload_time;
            sprite.sprite = grenage.sprite;
        }
    }
}

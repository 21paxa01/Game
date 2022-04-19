using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject Inventory_menu;
    public GameObject[] weapons_arr;
    public GameObject pistol;
    public GameObject shotgun;
    public GameObject ak_47;
    public GameObject rpg;
    public GameObject p_90;
    public GameObject snowgun;
    public bool clear;
    public int i;
    private int j = 0;
    public Image img;
    public GameObject[] now_weapon;
    public GameObject[] cells_arr;
    public Image weapon_sprite;
    public Image cell_sprite;
    public inventory_weapon script;
    public Save save_script;
    public GameObject cell1; public GameObject cell2; public GameObject cell3; public GameObject cell4; public GameObject cell5; public GameObject cell6;
    void Start()
    {
        save_script = GameObject.Find("save").GetComponent<Save>();
        save_script.Load();
        j = save_script.inv_j;
        now_weapon = new GameObject[2];
        i = 0;
        weapons_arr = new GameObject[6];
        weapons_arr[0] = pistol;weapons_arr[1] = shotgun;weapons_arr[2] = ak_47; weapons_arr[3] = rpg;weapons_arr[4] = p_90; weapons_arr[5] = snowgun;
        cells_arr = new GameObject[6];
        cells_arr[0] = cell1;cells_arr[1] = cell2; cells_arr[2] = cell3; cells_arr[3] = cell4; cells_arr[4] = cell5; cells_arr[5] = cell6;
    }

    void Update()
    {
        
    }
    public void Inventory_ON()
    {
        Inventory_menu.SetActive(true);
        clear = true;
    }
    public void Inventory_OFF()
    {
        Inventory_menu.SetActive(false);
    }
    public void Weapon_OFF()
    {
        weapons_arr[i].SetActive(false);
    }
    public void Weapon_ON()
    {
        weapons_arr[i].SetActive(true);
        img = weapons_arr[i].GetComponent<Image>();
    }
    public void NewWeapon()
    {
        save_script.Load();
        j = save_script.inv_j; ;
        ChekSells();
        script = cells_arr[j].GetComponent<inventory_weapon>();
        script.i = i;
        cell_sprite = cells_arr[j].GetComponent<Image>();
        weapon_sprite = weapons_arr[i].GetComponent<Image>();
        cell_sprite.sprite = weapon_sprite.sprite;
    }
    public void ChekSells()
    {
        for(int k=0;k<=j;k++)
            cells_arr[k].SetActive(true);
    }
}

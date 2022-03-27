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
    public bool clear;
    public int i;
    public Image img;
    public GameObject[] now_weapon;
    void Start()
    {
        now_weapon = new GameObject[2];
        i = 0;
        weapons_arr = new GameObject[3];
        weapons_arr[0] = pistol;weapons_arr[1] = shotgun;weapons_arr[2] = ak_47;
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
}

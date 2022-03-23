using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapons_upgrade: MonoBehaviour
{
    public GameObject pistol;
    public GameObject shotgun;
    public GameObject ak47;
    public GameObject awp;
    public GameObject pistol_ammo;
    public GameObject shotgun_ammo;
    public GameObject ak47_ammo;
    public GameObject awp_ammo;
    public float[] damage_arr = { 0f, 0f, 0f, 0f };
    public float[] reload_arr = { 1f, 1f, 1f, 1f };
    public float[] ammunition_arr = { 0f, 0f, 0f, 0f };
    public int[] damage_count = { 0, 0, 0, 0 };
    public int[] reload_count = { 0, 0, 0, 0 };
    public int[] ammunition_count = { 0, 0, 0, 0 };
    private GameObject[] weapons_arr;
    private GameObject[] ammo_arr;
    private ammo ammo_script;
    private shoting shoting_script;
    void Start()
    {
        weapons_arr = new GameObject[4];
        ammo_arr = new GameObject[4];
        weapons_arr[0] = pistol;weapons_arr[1] = shotgun;weapons_arr[2] = ak47;weapons_arr[3] = awp;
        ammo_arr[0] = pistol_ammo;ammo_arr[1] = shotgun_ammo;ammo_arr[2] = ak47_ammo;ammo_arr[3] = awp_ammo;
    }

    
    void Update()
    {
        
    }
    public void ChangeStats()
    {
        for(int i = 0; i < 4; i++)
        {
            ammo_script = ammo_arr[i].gameObject.GetComponent<ammo>();
            shoting_script = weapons_arr[i].GetComponent<shoting>();
            ammo_script.ammo_damage = ammo_script.default_damage + ammo_script.default_damage * damage_arr[i];
            shoting_script.Ammunition = shoting_script.DefaultAmmunition + shoting_script.DefaultAmmunition *ammunition_arr[i];
            shoting_script.ReloadTime = shoting_script.DefaultReloadTime * reload_arr[i];
        }
    }
}

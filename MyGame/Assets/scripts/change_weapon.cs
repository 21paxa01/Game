using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class change_weapon : MonoBehaviour
{
    public GameObject pistol;
    public GameObject ak47;
    public GameObject awp;
    public GameObject rpg;
    public GameObject p_90;
    public GameObject snowgun;
    private bill script_bill;
    public GameObject shohtgun;
    public GameObject change_button;
    public static int change = 0;
    public AudioSource change_sound;
    public GameObject[] weapons;
    public GameObject shoting;
    private shoting script;
    public bool[] chek= { false,false,false,false,false,false,false};
    private bool find;
    public static int k = 1;
    private int l=7;
    public int test;
    void Start()
    {
        script_bill = GetComponent<bill>();
        weapons = new GameObject[7];
        weapons[0] = pistol;weapons[1] = shohtgun;weapons[2] = ak47;weapons[3] = rpg; weapons[4] = p_90; weapons[5]=snowgun; weapons[6] = awp;
        if (PlayerPrefs.HasKey("weapon_count"))
        {
            k = PlayerPrefs.GetInt("weapon_count");
        }
        Chek();
    }

    
    void Update()
    {
        test = change;
        PlayerPrefs.SetInt("weapon_count", k);
        if (k < 2)
        {
            change_button.SetActive(false);
        }
        shoting= weapons[change];
    }

    public void Change()
    {
        script = shoting.gameObject.GetComponent<shoting>();
        if (script.ReloaD == false&&k>1)
        {
            find = false;
            weapons[change].SetActive(false);
            for(int i = change+1; i < l; i++)
            {
                if (chek[i] == true)
                {
                    change = i;
                    find = true;
                    break;
                }
            }
            if (find == false)
            {
                for(int i = 0; i < change; i++)
                {
                    if (chek[i] == true)
                    {
                        change = i;
                        find = true;
                        break;
                    }
                }
            }
            weapons[change].SetActive(true);
            script.stop = false;
            change_sound.Play();
        }
    }
    public void update()
    {
        for(int i = 0; i < 7; i++)
        {
            if (chek[i] == true)
            {
                script = weapons[i].GetComponent<shoting>();
                script.ReloaD = false;
                script.reload = 0;
                script.stop = false;
            }
        }
    }
    void Chek()
    {
        for(int i = 0; i < 7; i++)
        {
            if (chek[i] == true)
            {
                script_bill.weapon_chek = true;
                break;
            }
        }
    }
    public void Activate_weapon()
    {
        for(int i = 0; i < 7; i++)
        {
            if (chek[i] == true)
            {
                weapons[i].SetActive(true);
                change = i;
                break;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class change_weapon : MonoBehaviour
{
    public GameObject pistol;
    public GameObject ak47;
    public GameObject awp;
    public GameObject shohtgun;
    public GameObject change_button;
    public static int change = 0;
    public AudioSource change_sound;
    public GameObject[] weapons;
    public GameObject shoting;
    private shoting script;
    public bool[] chek= { false,false,false,false};
    private bool find;
    public static int k = 2;
    private int l=4;
    void Start()
    {
        weapons = new GameObject[4];
        weapons[0] = pistol;weapons[1] = shohtgun;weapons[2] = ak47;weapons[3] = awp;
        if (PlayerPrefs.HasKey("weapon_count"))
        {
            k = PlayerPrefs.GetInt("weapon_count");
        }
    }

    
    void Update()
    {
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
}

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
    private GameObject[] weapons;
    public GameObject shoting;
    private shoting script;
    private bool[] chek= { true,false,false,false};
    public static int k = 1;
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
            weapons[change].SetActive(false);
            change++;
            if (change == k)
                change = 0;
            weapons[change].SetActive(true);
            script.stop = false;
            change_sound.Play();
        }
    }
}

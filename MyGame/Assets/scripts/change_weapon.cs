using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class change_weapon : MonoBehaviour
{
    public GameObject pistol;
    public GameObject ak47;
    public GameObject awp;
    public int change = 1;
    public AudioSource change_sound;
    void Start()
    {
        ak47.SetActive(false);
        awp.SetActive(false);
    }

    
    void Update()
    {
        
    }
    public void Change()
    {
        change++;
        if (change == 4)
            change = 1;
        if (change == 1)
        {
            pistol.SetActive(true);
            ak47.SetActive(false);
            awp.SetActive(false);
        }
        if (change == 2)
        {
            pistol.SetActive(false);
            ak47.SetActive(true);
            awp.SetActive(false);
        }
        if(change==3)
        {
            pistol.SetActive(false);
            ak47.SetActive(false);
            awp.SetActive(true);
        }
        change_sound.Play();
    }
}

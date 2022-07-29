using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bestiary_cell : MonoBehaviour
{
    public int i;
    private int j;
    public Bestiary script;
    private Image img;
    void Start()
    {
        script = GameObject.Find("Home_Canvas").GetComponent<Bestiary>();
        img = GetComponent<Image>();
    }


    void Update()
    {
        j = i + script.j;
        if (j < script.zomb_kol)
        {
            img.color = new Color(1, 1, 1, 1);
            img.sprite = script.icons_img[j];
        }
        else
            img.color = new Color(1, 1, 1, 0);
    }
    /*public void Update_icon()
    {
        zombies[i + j].SetActive(false);
        j = script.i;
        if (script.chek[i + j] == true)
        {
            zombies[i + j].SetActive(true);
        }
    }*/
    public void Take_zombie()
    {
        script.Zombie_OFF();
        script.i = j;
        script.Zombie_ON();
    }
}

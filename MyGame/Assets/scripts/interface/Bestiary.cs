using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bestiary : MonoBehaviour
{
    public GameObject bobo;
    public GameObject bibo;
    public GameObject bo;
    public GameObject karl;
    public GameObject bird;
    public GameObject lara;
    public GameObject martin;
    public GameObject mike;
    public int i;
    public int j;
    private GameObject[] zombies;
    public GameObject Bestiary_menu;
    public bool[] chek = { false, false, false, false, false, false, false, false };
    private string[] zomb_info = { "bobo", "karl", "bird", "bibo", "lara", "martin", "mike", "bo" };
    public GameObject info;
    private Text info_text;
    public int zomb_kol;
    void Start()
    {
        i = 0;
        j = 0;
        zombies = new GameObject[8];
        zombies[0] = bobo; zombies[1] = karl; zombies[2] = bird; zombies[3] = bibo; zombies[4] = lara; zombies[5] = martin; zombies[6] = mike; zombies[7] = bo;
        info_text = info.GetComponent<Text>();
    }

    
    void Update()
    {
        
    }
    public void Zombie_ON()
    {
        if (chek[i + j] == true)
        {
            zombies[i + j].SetActive(true);
            info_text.text = zomb_info[i + j];
        }
    }
    public void Zombie_OFF()
    {
        for (int k = 0; k < 8; k++)
            zombies[k].SetActive(false);
        info_text.text = "";
    }
    public void right()
    {
        if (i < 5&&chek[i+2]==true)
            i++;
    }
    public void left()
    {
        if (i > 0)
            i--;
    }
    public void Menu_ON()
    {
        Bestiary_menu.SetActive(true);
    }
    public void Menu_OFF()
    {
        Bestiary_menu.SetActive(false);
    }
    public void Chek_zombies()
    {
        for (int k = 0; k < zomb_kol; k++)
            chek[k] = true;
    }
}

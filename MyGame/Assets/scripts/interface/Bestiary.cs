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
    public GameObject richard;
    public GameObject boom_bird;
    public GameObject gru;
    public GameObject[] cells_arr;
    public GameObject cell_1, cell_2, cell_3, cell_4, cell_5, cell_6, cell_7, cell_8, cell_9, cell_10;
    public int i;
    public int j;
    private GameObject[] zombies;
    public GameObject Bestiary_menu;
    public bool[] chek = { false, false, false, false, false, false, false, false,false,false };
    private string[] zomb_info = { "bobo", "karl", "bird", "bibo", "lara", "martin", "mike", "bo", "", "", "" };
    public GameObject info;
    private Text info_text;
    public int zomb_kol;
    public GameObject up, down;
    public Sprite[] icons_img;
    public Sprite bobo_sprite, karl_sprite, bird_sprite, gru_sprite, bibo_sprite,boom_bird_sprite, lara_sprite, richard_sprite, martin_sprite, mike_sprite, bo_sprite;
    void Start()
    {
        i = 0;
        j = 0;
        zombies = new GameObject[11];
        zombies[0] = bobo; zombies[1] = karl; zombies[2] = bird; zombies[3] = gru; zombies[4] = bibo;zombies[5] = boom_bird; zombies[6] = lara;zombies[7] = richard; zombies[8] = martin; zombies[9] = mike; zombies[10] = bo;
        icons_img = new Sprite[11];
        icons_img[0]=bobo_sprite; icons_img[1]=karl_sprite; icons_img[2]=bird_sprite; icons_img[3]=gru_sprite; icons_img[4]=bibo_sprite;icons_img[5] = boom_bird_sprite; icons_img[6]=lara_sprite; icons_img[7]=richard_sprite; icons_img[8]=martin_sprite; icons_img[9]=mike_sprite; icons_img[10]=bo_sprite;
        info_text = info.GetComponent<Text>();
        cells_arr = new GameObject[10];
        cells_arr[0] = cell_1; cells_arr[1] = cell_2; cells_arr[2] = cell_3; cells_arr[3] = cell_4; cells_arr[4] = cell_5; cells_arr[5] = cell_6; cells_arr[6] = cell_7; cells_arr[7] = cell_8; cells_arr[8] = cell_9; cells_arr[9] = cell_10;
    }

    
    void Update()
    {
        if (j == 0)
            up.SetActive(false);
        else
            up.SetActive(true);
        if (j == 2||zomb_kol<10)
            down.SetActive(false);
        else
            down.SetActive(true);
    }
    public void Zombie_ON()
    {
        zombies[i].SetActive(true);
        info_text.text = zomb_info[i];
    }
    public void Zombie_OFF()
    {
        for (int k = 0; k < zomb_kol; k++)
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
        for (int k = 0; k < 10; k++)
        {
            chek[k] = true;
            cells_arr[k].SetActive(true);
        }
    }
    public void UP()
    {
        j-=2;
    }
    public void DOWN()
    {
        j+=2;
    }
}

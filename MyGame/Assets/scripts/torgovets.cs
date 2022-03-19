using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class torgovets : MonoBehaviour
{
    public GameObject ShopMenu;
    public GameObject SkinsMenu;
    public GameObject WeaponsMenu;
    public GameObject ChoiseMenu;
    public GameObject WeaponsChoiseMenu;
    public GameObject capsul_1;
    public GameObject capsul_2;
    public GameObject capsul_3;
    public GameObject fon;
    public GameObject shotgun;
    public GameObject ak47;
    public SpriteRenderer sp;
    public static bool shop;
    private float[] x_arr = { 0.87f, 1.3f, 1.7f };
    private float[] y_arr ={ 0.35f,0.275f,0.425f };
    private GameObject[] capsul_arr;
    private GameObject[] weapons_arr;
    private float[] w_prise_arr = { 250f,1000f };
    private string[] w_range_arr = { "short","middle" };
    private float[] w_damage_arr = { 30f,10f };
    private string[] w_reload_arr = { "1.5", "0.1" };
    private float[] w_ammunition_arr = { 15f, 30f };
    private string[] w_name_arr = { "shotgun", "ak-47" };
    public Text w_prise;
    public Text buy_prise;
    public Text w_range;
    public Text w_damage;
    public Text w_reload;
    public Text w_ammunition;
    public Text w_name;
    private int i;
    private int j;
    void Start()
    {
        capsul_arr = new GameObject[3];
        capsul_arr[0] = capsul_1;capsul_arr[1] = capsul_2;capsul_arr[2] = capsul_3;
        weapons_arr = new GameObject[2];
        weapons_arr[0] = shotgun; weapons_arr[1] = ak47;
    }
    void Update()
    {
        if (shop == true)
        {
            ShopMenu.SetActive(true);
            fon.SetActive(true);
        }
        else
        {
            ShopMenu.SetActive(false);
            fon.SetActive(false);
        }
    }
    public void Skins()
    {
        sp = capsul_arr[0].GetComponent<SpriteRenderer>();
        sp.sortingOrder = 21;
        SkinsMenu.SetActive(true);
        ShopCamera.x = 0.87f;
        ShopCamera.y=0.35f;
        ZoomCamera.zoom = 0.3f;
        ChoiseMenu.SetActive(false);
    }
    public void Weapons()
    {

        j = 0;
        weapons_arr[j].SetActive(true);
        sp = capsul_arr[0].GetComponent<SpriteRenderer>();
        WeaponsMenu.SetActive(true);
        w_prise = GameObject.Find("prise").GetComponent<Text>();
        w_range = GameObject.Find("range").GetComponent<Text>();
        w_damage = GameObject.Find("damage").GetComponent<Text>();
        w_reload = GameObject.Find("reload").GetComponent<Text>();
        w_ammunition = GameObject.Find("ammunition").GetComponent<Text>();
        w_name = GameObject.Find("name").GetComponent<Text>();
        w_prise.text = w_prise_arr[j].ToString();
        w_name.text = w_name_arr[j].ToString();
        w_range.text = w_range_arr[j].ToString();
        w_damage.text = w_damage_arr[j].ToString();
        w_reload.text = w_reload_arr[j].ToString();
        w_ammunition.text = w_ammunition_arr[j].ToString();
        ShopCamera.x = -0.88f;
        ShopCamera.y = 0.55f;
        ZoomCamera.zoom = 0.3f;
        ChoiseMenu.SetActive(false);
    }
    public void BackToChoise()
    {
        sp.sortingOrder = 1;
        SkinsMenu.SetActive(false);
        WeaponsMenu.SetActive(false);
        weapons_arr[j].SetActive(false);
        ShopCamera.x = 0f;
        ZoomCamera.zoom = 0.7f;
        ShopCamera.y = 0.2f;
        ChoiseMenu.SetActive(true);
    }
    public void ShopOff()
    {
        shop = false;
    }
    public void Skins_left()
    {
        sp.sortingOrder = 1;
        i--;
        if (i == -1)  
            i = 2;
        sp = capsul_arr[i].GetComponent<SpriteRenderer>(); 
        sp.sortingOrder = 21;
        ShopCamera.x = x_arr[i];
        ShopCamera.y = y_arr[i];
    }
    public void Skins_right()
    {
        sp.sortingOrder = 1;
        i++;
        if (i == 3)
            i = 0;
        sp = capsul_arr[i].GetComponent<SpriteRenderer>(); 
        sp.sortingOrder = 21;
        ShopCamera.x = x_arr[i];
        ShopCamera.y = y_arr[i];
}
    public void Weapons_rigth()
    {
        weapons_arr[j].SetActive(false);
        j++;
        if (j == 2)
            j = 0;
        weapons_arr[j].SetActive(true) ;
        w_prise.text = w_prise_arr[j].ToString();
        w_name.text = w_name_arr[j].ToString();
        w_range.text = w_range_arr[j].ToString();
        w_damage.text = w_damage_arr[j].ToString();
        w_reload.text = w_reload_arr[j].ToString();
        w_ammunition.text = w_ammunition_arr[j].ToString();
    }
    public void Weapons_left()
    {
        weapons_arr[j].SetActive(false);
        j--;
        if (j == -1)
            j = 1;
        weapons_arr[j].SetActive(true);
        w_prise.text = w_prise_arr[j].ToString();
        w_name.text = w_name_arr[j].ToString();
        w_range.text = w_range_arr[j].ToString();
        w_damage.text = w_damage_arr[j].ToString();
        w_reload.text = w_reload_arr[j].ToString();
        w_ammunition.text = w_ammunition_arr[j].ToString();
    }
    public void Buy_weapon()
    {
        if (change_weapon.k < 2&&MoneyCount.mon>=250)
        {
            MoneyCount.mon -= 250;
            change_weapon.k++;
        }
        WeaponsChoiseMenu.SetActive(false);
    }
    public void Weapon_Buy_Or_Not()
    {
        WeaponsChoiseMenu.SetActive(true);
        buy_prise= GameObject.Find("buy_prise").GetComponent<Text>();
        buy_prise.text = w_prise_arr[j].ToString()+"?";

    }
    public void BackToWeapons()
    {
        WeaponsChoiseMenu.SetActive(false);
    }
}
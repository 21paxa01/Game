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
    public GameObject capsul_1;
    public GameObject capsul_2;
    public GameObject capsul_3;
    public GameObject fon;
    public GameObject shotgun;
    public GameObject ak47;
    public SpriteRenderer sp;
    public static bool shop;
    private float[] x_arr = { 0.87f, 1.3f, 1.7f };
    private GameObject[] capsul_arr;
    private GameObject[] weapons_arr;
    private float[] w_prise_arr = { 250f,1000f };
    public Text text;
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
        ZoomCamera.zoom = 0.7f;
        ChoiseMenu.SetActive(false);
    }
    public void Weapons()
    {

        j = 0;
        weapons_arr[j].SetActive(true);
        sp = capsul_arr[0].GetComponent<SpriteRenderer>();
        WeaponsMenu.SetActive(true);
        text = GameObject.Find("prise").GetComponent<Text>();
        text.text = w_prise_arr[j].ToString();
        ShopCamera.x = -0.86f;
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
        ShopCamera.y = 0f;
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
        if (i == 1)
            ShopCamera.y = -0.1f;
        else
            ShopCamera.y = 0f;
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
        if (i == 1)
            ShopCamera.y = -0.1f;
        else
            ShopCamera.y = 0f;
    }
    public void Weapons_rigth()
    {
        weapons_arr[j].SetActive(false);
        j++;
        if (j == 2)
            j = 0;
        weapons_arr[j].SetActive(true) ;
        text.text = w_prise_arr[j].ToString();
    }
    public void Weapons_left()
    {
        weapons_arr[j].SetActive(false);
        j--;
        if (j == -1)
            j = 1;
        weapons_arr[j].SetActive(true);
        text.text = w_prise_arr[j].ToString();
    }
    public void Buy_weapon()
    {
        if (change_weapon.k < 2&&MoneyCount.mon>=250)
        {
            MoneyCount.mon -= 250;
            change_weapon.k++;
        }
    }
}


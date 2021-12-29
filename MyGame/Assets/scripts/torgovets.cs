using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torgovets : MonoBehaviour
{
    public GameObject ShopMenu;
    public GameObject SkinsMenu;
    public GameObject WeaponsMenu;
    public GameObject ChoiseMenu;
    public GameObject fon;
    public static bool shop;
    private float[] x_arr = { 0.87f, 1.3f, 1.7f };
    private int i;
    void Start()
    {
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
        SkinsMenu.SetActive(true);
        ShopCamera.x = 0.87f;
        ChoiseMenu.SetActive(false);
    }
    public void Weapons()
    {
        WeaponsMenu.SetActive(true);
        ShopCamera.x = -0.86f;
        ShopCamera.y = 0.55f;
        ZoomCamera.zoom = 0.3f;
        ChoiseMenu.SetActive(false);
    }
    public void BackToChoise()
    { 
        SkinsMenu.SetActive(false);
        WeaponsMenu.SetActive(false);
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
        i--;
        if (i == -1)
            i = 2;
        ShopCamera.x = x_arr[i];
        if (i == 1)
            ShopCamera.y = -0.1f;
        else
            ShopCamera.y = 0f;
    }
    public void Skins_right()
    {
        i++;
        if (i == 3)
            i = 0;
        ShopCamera.x = x_arr[i];
        if (i == 1)
            ShopCamera.y = -0.1f;
        else
            ShopCamera.y = 0f;
    }
}

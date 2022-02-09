using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public SpriteRenderer sp;
    public static bool shop;
    private float[] x_arr = { 0.87f, 1.3f, 1.7f };
    private GameObject[] capsul_arr;
    private int i;
    void Start()
    {
        capsul_arr = new GameObject[3];
        capsul_arr[0] = capsul_1;capsul_arr[1] = capsul_2;capsul_arr[2] = capsul_3;
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
        WeaponsMenu.SetActive(true);
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
}

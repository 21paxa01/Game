using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject Inventory_menu;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void Inventory_ON()
    {
        Inventory_menu.SetActive(true);
    }
    public void Inventory_OFF()
    {
        Inventory_menu.SetActive(false);
    }
}

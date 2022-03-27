using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory_weapon : MonoBehaviour
{
    public GameObject inventory;
    public Inventory script;
    public int i;
    void Start()
    {
        script = inventory.GetComponent<Inventory>();
    }

    void Update()
    {
        
    }
    public void Weapon_ON()
    {
        script.Weapon_OFF();
        script.i = i;
        script.Weapon_ON();
        script.clear = false;
    }
}

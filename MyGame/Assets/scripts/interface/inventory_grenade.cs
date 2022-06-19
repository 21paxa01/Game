using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory_grenade : MonoBehaviour
{
    public GameObject inventory;
    public Inventory script;
    public int i;
    private change_weapon change_weapon;
    public GameObject bill;
    public GameObject light;
    void Start()
    {
        bill = GameObject.Find("Bill");
        change_weapon = bill.GetComponent<change_weapon>();
        script = inventory.GetComponent<Inventory>();
    }

    void Update()
    {

    }
    public void Grenade_ON()
    {
        script.Grenade_OFF();
        //script.Light_off();
        //change_weapon.weapons[script.i].SetActive(false);
        script.i = i;
        script.Grenade_ON();
        //light.SetActive(true);
        //change_weapon.weapons[i].SetActive(true);
        /*if (i == 6)
        {
            stick = GameObject.Find("stick");
            stick_script = stick.GetComponent<stick>();
            stick_script.inventory = true;
            stick.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 90);
            stick.transform.position = new Vector3(bill.transform.position.x + 0.1f, bill.transform.position.y + 0.1452f, transform.position.z);
        }*/
        script.stop = false;
    }
}

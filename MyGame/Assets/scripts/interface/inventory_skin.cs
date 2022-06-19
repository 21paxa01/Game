using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory_skin : MonoBehaviour
{
    public GameObject inventory;
    public Inventory script;
    public int i;
    public GameObject bill;
    //public GameObject light;
    private SpriteRenderer weapon_sprite;
    private SpriteRenderer sprite;
    private bill b_script;
    void Start()
    {
        bill = GameObject.Find("Bill");
        sprite = bill.GetComponent<SpriteRenderer>();
        script = inventory.GetComponent<Inventory>();
        b_script = bill.GetComponent<bill>();
    }

    void Update()
    {

    }
    public void Skin_ON()
    {
        script.Skin_OFF();
        script.s_i = i;
        script.Skin_ON();
    }
    public void Bill_ON()
    {
        script.Skin_OFF();
        b_script.skin = false;
        script.s_i = 0;
        script.inv_bill.SetActive(true);
        sprite.color = new Color(1f, 1f, 1f, 1f);
    }
}

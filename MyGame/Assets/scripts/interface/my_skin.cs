using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class my_skin : MonoBehaviour
{
    public GameObject inventory;
    public Inventory script;
    public Image skin;
    public GameObject skin_img;
    //public GameObject cell;
    //private granade_cell cell_script;
    //private grenage grenage_script;
    void Start()
    {
        script = inventory.GetComponent<Inventory>();
        skin = skin_img.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Take_skin()
    {
        skin_img.SetActive(true);
        skin.sprite = script.img.sprite;
        script.Active_Skin();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class computer : MonoBehaviour
{
    public GameObject computer_menu;
    public GameObject anonim;
    private SpriteRenderer sp;
    void Start()
    {
    }

    void Update()
    {
        
    }
    public void Menu_ON()
    {
        anonim = GameObject.Find("anonim_icon");
        sp = anonim.GetComponent<SpriteRenderer>();
        sp.sortingOrder = -1;
        computer_menu.SetActive(true);
    }
    public void Menu_OFF()
    {
        computer_menu.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class computer : MonoBehaviour
{
    public GameObject computer_menu;
    public GameObject anonim;
    public GameObject fon;
    private SpriteRenderer sp;
    public GameObject phrases;
    private anonim_phrases script;
    private Save save_script;
    void Start()
    {
        save_script = GameObject.Find("save").GetComponent<Save>();
        script =phrases.GetComponent<anonim_phrases>();
        save_script.Load_anonim();
        script.inventory = save_script.save_anonim_inventory;
        script.first_wave = save_script.save_anonim_first_wave;
    }

    void Update()
    {
        
    }
    public void Menu_ON()
    {
        anonim = GameObject.Find("anonim_icon");
        sp = anonim.GetComponent<SpriteRenderer>();
        sp.sortingOrder = -1;
        fon = GameObject.Find("anonim_fon");
        sp = fon.GetComponent<SpriteRenderer>();
        sp.sortingOrder = -1;
        computer_menu.SetActive(true);
    }
    public void Menu_OFF()
    {
        computer_menu.SetActive(false);
        script.i = 0;
        if(script.first_wave==true&& script.inventory!=1)
            script.first_wave = false;
        if (script.inventory == 1)
            script.inventory = 2;
        save_script.save_anonim_inventory= script.inventory;
        save_script.save_anonim_first_wave= script.first_wave;
        save_script.Save_anonim();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class anonim_phrases : MonoBehaviour
{
    public Text text;
    public int i;
    public int l;
    public GameObject computer_menu;
    public int inventory = 0;
    public bool  first_wave=true;
    public GameObject right;
    public GameObject left;
    private bool stop = false;
    private string[] inventory_phrases = { "Welcome to inventory! On the left you see all the weapons available to you. To take them with you on a mission, drag the desired weapon from the window on the left to the right window. Remember that you can take a limited amount of equipment on a mission." };
    private string[] first_phrases = { "HI Bill! Welcome to your new home. I'm here to increase your chances of survival. You don't need to know my name. There are many infected outside. Your task is to clear the area around the base from zombies.", "If you do well, you can earn money for new weapons or costumes. Learn more about it in the shop. Weapons can also be upgraded, ask the mechanic about it. Well, maybe you'll have better luck than the previous occupants of this room. See you!" };
    private string[] random_phrases = { "If you want to know more about the zombies you encountered, then you can find detailed information in the bestiary in the settings." };
    void Start()
    {
        i = 0;
        text = GetComponent<Text>();
    }

    void Update()
    {
        if (stop == false)
        {
            if (first_wave==true&&inventory!=1)
            {
                l = 1;
                text.text = first_phrases[i];
            }
            else if (inventory == 1)
            {
                i = 0;
                l = 0;
            }
            else
            {
                l = 0;
                text.text = random_phrases[i];
            }
        }
        if (i == 0)
            left.SetActive(false);
        else
            left.SetActive(true);
        if(i==l)
            right.SetActive(false);
        else
            right.SetActive(true);
    }
    public void Right()
    {
        if (i==l)
            i = 0;
        else
            i++;
    }
    public void Left()
    {
        if (i == 0)
            i = l;
        else
            i--;
    }
    public void Inventory()
    {
        if (inventory <1)
        {
            text = GetComponent<Text>();
            computer_menu.SetActive(true);
            text.text =inventory_phrases[0];
        }
        inventory++;
    }
    public void Inventory_OFF()
    {
        stop = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class locked_cell : MonoBehaviour
{
    public Sprite locked;
    public Sprite unlocked;
    private Inventory script;
    private Image img;
    public int i;
    void Start()
    {
        script = GameObject.Find("Home_Canvas").GetComponent<Inventory>();
        img = GetComponent<Image>();
    }

    void Update()
    {
        if (script.category_i == i)
        {
            img.sprite = locked;
        }
        else
        {
            img.sprite = unlocked;
        }
    }
}

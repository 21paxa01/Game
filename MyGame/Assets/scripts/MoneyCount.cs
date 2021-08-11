using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCount : MonoBehaviour
{
    Text text;
    public static int money;
    public static int mon;
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mon > money + 1)
        {
            mon--;
            
        }
        money = mon;
        text.text = money.ToString();
        
    }
}

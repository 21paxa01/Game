using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyTasks : MonoBehaviour
{
    public GameObject tasks_menu;
    public GameObject pause_menu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MenuON() 
    {
        tasks_menu.SetActive(true);
        pause_menu.SetActive(false);
    }
    public void MenuOFF() 
    {
        pause_menu.SetActive(true);
        tasks_menu.SetActive(false);
    }
}

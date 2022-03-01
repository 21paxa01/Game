using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class choise : MonoBehaviour
{
    private GameObject choise_menu;
    public GameObject choise_home;
    public GameObject choise_shop;
    public GameObject choise_lab;
    public string scene_name;
    void Start()
    {
        
    }

    void Update()
    {
        scene_name = SceneManager.GetActiveScene().name;
        if (scene_name == "SampleScene") 
            choise_menu = choise_home;
        else if (scene_name == "Shop") 
            choise_menu = choise_shop;
        else if (scene_name == "lab") 
            choise_menu = choise_lab;
    }
    public void Choise_ON()
    {
        choise_menu.SetActive(true);
    }
}

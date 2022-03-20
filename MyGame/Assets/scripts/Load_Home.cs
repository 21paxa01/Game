using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Home : MonoBehaviour
{
    public Transform bill;
    public GameObject perechod;
    public GameObject poison_head;
    public GameObject poison_icon;
    public GameObject wave;
    public GameObject RE;
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
    public void LoadHome()
    {
        StartCoroutine(PerechodToHome());
    }
    IEnumerator PerechodToHome()
    {
        choise_menu.SetActive(false);
        if (scene_name == "lab")
            lab_door.open_door = false;
        perechod.SetActive(true);
        yield return new WaitForSeconds(1f);
        wave.SetActive(true);
        RE.SetActive(true);
        SceneManager.LoadScene(1);
        ShopCamera.y = 0f;
        bill.position = new Vector3(4.2f, -4.98126411f, 0f);
        yield return new WaitForSeconds(1f);
        perechod.SetActive(false);
    }
}

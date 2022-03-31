using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Shop : MonoBehaviour
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
    public void LoadShop()
    {
        StartCoroutine(PerechodToShop());
        NoDestroy.destroy = true;
    }
    IEnumerator PerechodToShop()
    {
        choise_menu.SetActive(false);
        if (scene_name == "lab")
            lab_door.open_door = false;
        else
            home_door.open = true;
        perechod.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(2);
        ShopCamera.y = 0.2f;
        bill.position = new Vector3(6.72f, -11.56f, bill.position.z);
        yield return new WaitForSeconds(1f);
        perechod.SetActive(false);   
    }
}

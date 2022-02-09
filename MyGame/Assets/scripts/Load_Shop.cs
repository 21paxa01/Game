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
    void Start()
    {

    }

    void Update()
    {
        
    }
    public void LoadShop()
    {
        StartCoroutine(PerechodToShop());
        NoDestroy.destroy = true;
    }
    public void LoadHome()
    {
        StartCoroutine(PerechodToHome());
    }
    IEnumerator PerechodToShop()
    {
        perechod.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(2);
        ShopCamera.y = 0.2f;
        bill.position = new Vector3(6.72f, -11.56f, bill.position.z);
        yield return new WaitForSeconds(1f);
        perechod.SetActive(false);   
    }
    IEnumerator PerechodToHome()
    {
        perechod.SetActive(true);
        yield return new WaitForSeconds(1f);
        //poison_head.SetActive(true);
        //poison_icon.SetActive(true);
        wave.SetActive(true);
        SceneManager.LoadScene(1);
        ShopCamera.y = 0f;
        bill.position = new Vector3(4.2f, -4.98126411f, 0f);
        yield return new WaitForSeconds(1f);
        perechod.SetActive(false);
    }
}

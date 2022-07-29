using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class granade_cell : MonoBehaviour
{
    public GameObject granade;
    private Transform bill;
    public float reload_time;
    private bool reload;
    private float x, y, z,r;
    private float destroy_time;
    public GameObject image;
    private Image img;
    public float fill;
    void Start()
    {
        bill = GameObject.Find("Bill").GetComponent<Transform>();
        img = image.GetComponent<Image>();
        fill = 0f;
    }

    void Update()
    {
        img.fillAmount = fill;
        x = bill.position.x;
        y = bill.position.y;
        z = bill.position.z;
        if (bill.rotation.y == -1f)
            r = 135f;
        else
            r = 45f;
    }
    public void Granade()
    {
        if (reload == false)
        {
            Instantiate(granade, new Vector3(x,y+0.2f,z),Quaternion.Euler(0f,bill.rotation.y,r));
            StartCoroutine(Reload()); 
        }
    }
    IEnumerator Reload()
    {
        fill = 0f;
        reload = true;
        for (int i = 1; i <= reload_time * 10; i++)
        {
            yield return new WaitForSeconds(0.1f);
            fill =1-(1- i / (reload_time * 10));

        }
        reload = false;
        fill = 0f;
    }
    public void Update_cell()
    {
        reload = false;
        fill = 0f;
    }
}

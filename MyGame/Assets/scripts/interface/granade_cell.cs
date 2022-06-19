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
    public GameObject removed_time,image;
    private Text text;
    private Image img;
    public float fill;
    void Start()
    {
        bill = GameObject.Find("Bill").GetComponent<Transform>();
        text = removed_time.GetComponent<Text>();
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
        fill = 1f;
        removed_time.SetActive(true);
        text.text = reload_time.ToString();
        reload = true;
        for (int i = 1; i <= reload_time * 10; i++)
        {
            yield return new WaitForSeconds(0.1f);
            fill =1- i / (reload_time * 10);
            if (i % 10 == 0)
                text.text = (reload_time - i / 10).ToString();

        }
        reload = false;
        fill = 0f;
        removed_time.SetActive(false);
    }
}

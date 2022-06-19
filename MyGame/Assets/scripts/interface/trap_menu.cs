using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap_menu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public Transform Bill;
    public GameObject   rapt_menu_UI;
    public GameObject on_button;
    public GameObject off_button;
    public AudioSource pause_sound;
    private float dist = 0.5f;
    public GameObject wall;
    public GameObject boom;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (bill.faceRight == true)
            dist = 0.5f;
        else
            dist = -0.5f;
    }
    public void Off()
    {
        off_button.SetActive(false);
        on_button.SetActive(true);
    }
    public void Open()
    {
        on_button.SetActive(false);
        off_button.SetActive(true);
    }
    public void Wall()
    {
        if (bill.faceRight == true)
            wall.transform.localScale = new Vector3(1f, 1f, 1f);
        else
            wall.transform.localScale = new Vector3(-1f, 1f, 1f);
        Instantiate(wall, new Vector3(Bill.transform.position.x+dist, -3.0815f, 0f), wall.transform.rotation);
    }
    public void Boom()
    {
        if(bill.faceRight==true)
            boom.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        else
            boom.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        Instantiate(boom, new Vector3(Bill.transform.position.x + dist, -2.861f, 0f), boom.transform.rotation);
    }
}

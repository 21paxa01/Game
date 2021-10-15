using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rapt_menu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public Transform Bill;
    public GameObject   rapt_menu_UI;
    public GameObject on_button;
    public GameObject off_button;
    public AudioSource pause_sound;
    private float dist = 0.5f;
    public GameObject wall;
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
    public void Change()
    {
        Instantiate(wall, new Vector3(Bill.transform.position.x+dist, -3.0815f, 0f), wall.transform.rotation);
    }
}

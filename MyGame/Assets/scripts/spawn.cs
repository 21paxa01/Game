using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawn : MonoBehaviour
{
    public GameObject default_zombie;
    public GameObject bibo_zombie;
    public GameObject bo_zombie;
    public GameObject karl_zombie;
    public GameObject lara_zombie;
    public GameObject martin_zombie;
    public GameObject mike_zombie;
    private GameObject zombie;
    public Transform spawn_point_1;
    private Transform spawn_point;
    public Transform spawn_point_2;
    public GameObject restart;

    public static int wave=1;
    public Text text;
    private float fill;
    public Image bar;
    public GameObject bill;
    private bill script;
    public GameObject death;
    private death scr;


    Coroutine spawn_zombie;
    public float spawn_time;
    public int i;
    public GameObject WAVE;
    public GameObject bill_icon;
    
    void Start()
    {
        WAVE = GameObject.Find("Wave");
        bill = GameObject.Find("Bill");
        restart= GameObject.Find("RE");
        restart.SetActive(false);
        //bill_icon = GameObject.Find("bill");
        //bill_icon.transform.position = new Vector3(4.97f, -2.1709f, 90f);
        death = GameObject.Find("Canvas");
        scr= death.gameObject.GetComponent<death>();
        bar = GameObject.Find("zomb_wave_top").GetComponent<Image>();
        text = GameObject.Find("Count").GetComponent<Text>();
        WAVE.SetActive(false);
        fill = 0f;
        script = bill.gameObject.GetComponent<bill>();
        //text = GetComponent<Text>();
    }


    void Update()
    {
        bar.fillAmount = fill;
        text.text = wave.ToString();
        SpawnPoint();
        Zombies();
        //bill_icon.transform.position = new Vector3(5.986f + 3.42f*fill, -0.273f, 90f) ;
        if (start == true)
        {
            start = false;
            StartCoroutine(Spawn());
            StartCoroutine(Wave());
        }
    }
    public static bool start;
    public void spawn_zombies()
    {
        StartCoroutine(Wave());
        StartCoroutine(Spawn());

    }
    public static int a;
    IEnumerator Spawn()
    {
        a = 0;
        while (a<1)
        {
            Instantiate(zombie,spawn_point.position,transform.rotation);
            yield return new WaitForSeconds(spawn_time);
        }

    }

    void SpawnPoint()
    {
        int spawn_value = Random.Range(0, 2);
        if (spawn_value == 0)
        {
            spawn_point = spawn_point_1;
        }
        else
        {
            spawn_point = spawn_point_2;
        }
    }
    void Zombies()
    {
        int zombie_value = Random.Range(0, 100);
        /*if (zombie_value<10)
        {
            zombie = bo_zombie;
            
        }
        else if(zombie_value>=10&&zombie_value<35)
        {
            zombie =bibo_zombie;
        }*/
        if (zombie_value >= 0 && zombie_value < 32)
        {
            zombie = karl_zombie;
        }/*
        else if (zombie_value >= 50 && zombie_value <53)
        {
            zombie = lara_zombie;
        }
        else if (zombie_value >= 53 && zombie_value < 88)
        {
            zombie = martin_zombie;
        }
        else if (zombie_value >= 88 && zombie_value < 113000)
        {
            zombie = mike_zombie;
        }*/
        else
        {
            zombie = default_zombie;
        }
    }
    public static int wave_time=120;
    IEnumerator Wave()
    {
        a = 0;
        while (a < 1)
        {
            yield return new WaitForSeconds(0.01f);
            fill += (0.01f / wave_time);
            if (fill >= 1)
            {
                fill = 0f;
                a = 1;
            }
        }
        if (a == 1)
        {
            wave_img.victory = true;
            restart.SetActive(true);
            StopCoroutine(Spawn());
        }
    }
    void WavE()
    {
        a = 0;
        wave++;
        wave_time += 6;
        //spawn_time -= 0.2f;
        //StartCoroutine(Wave());
        
    }
    //karl=32%,41%,50%;
}

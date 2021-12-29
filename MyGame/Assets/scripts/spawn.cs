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

    public int wave = 1;
    public Text text;
    private float fill;
    public Image bar;

    

    Coroutine spawn_zombie;
    public float spawn_time;
    public int i;
    public GameObject WAVE;
    
    void Start()
    {
        WAVE = GameObject.Find("Wave");
        bar = GameObject.Find("zomb_wave_in").GetComponent<Image>();
        text = GameObject.Find("Count").GetComponent<Text>();
        WAVE.SetActive(false);
        fill = 0f;
        //text = GetComponent<Text>();
    }


    void Update()
    {
        bar.fillAmount = fill;
        text.text = wave.ToString();
        SpawnPoint();
        Zombies();
        if (start == true)
        {
            start = false;
            StartCoroutine(Spawn());
        }
    }
    public static bool start;
    public void spawn_zombies()
    {
        StartCoroutine(Wave());
        StartCoroutine(Spawn());

    }
    public int a = 0;
    IEnumerator Spawn()
    {

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
        int zombie_value = Random.Range(0, 150);
        if (zombie_value<10)
        {
            zombie = bo_zombie;
            
        }
        else if(zombie_value>=10&&zombie_value<35)
        {
            zombie =bibo_zombie;
        }
        else if (zombie_value >= 35 && zombie_value < 50)
        {
            zombie = karl_zombie;
        }
        else if (zombie_value >= 50 && zombie_value <53)
        {
            zombie = lara_zombie;
        }
        else if (zombie_value >= 53 && zombie_value < 88)
        {
            zombie = martin_zombie;
        }
        /*else if (zombie_value >= 88 && zombie_value < 113)
        {
            zombie = mike_zombie;
        }*/
        else
        {
            zombie = default_zombie;
        }
    }
    public int wave_time;
    IEnumerator Wave()
    {
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

        WavE();
    }
    void WavE()
    {
        a = 0;
        wave++;
        spawn_time -= 0.4f;
        StartCoroutine(Wave());
    }
}

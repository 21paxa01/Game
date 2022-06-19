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

    public float test1;
    public GameObject boss;

    public static int wave =1;
    //public Text text;
    public float fill;
    public Image bar;
    public GameObject bill;
    private bill script;
    public GameObject death;
    private death scr;
    private int[] zombie_chance;
    public static int zombie_kol;
    private GameObject[] zombie_arr;
    private int l=2;

    Coroutine spawn_zombie;
    public float spawn_time;
    public int i;
    public GameObject WAVE;
    public RectTransform bill_icon;
    public int test;


    public SpriteRenderer town;
    public Sprite town_1;
    public Sprite town_2;
    public Sprite town_3;
    private Bestiary bestiary;
    void Start()
    {
        zombie_arr = new GameObject[2];
        zombie_chance = new int[2];
        bestiary = GameObject.Find("Home_Canvas").GetComponent<Bestiary>();
        ChangeChance();
        zombie_kol = 0;
        WAVE = GameObject.Find("Wave");
        bill = GameObject.Find("Bill");
        bill_icon = GameObject.Find("bill").GetComponent<RectTransform>();
        death = GameObject.Find("Canvas");
        scr= death.gameObject.GetComponent<death>();
        bar = GameObject.Find("zomb_wave_top").GetComponent<Image>();
        //text = GameObject.Find("Count").GetComponent<Text>();
        fill = 0f;
        script = bill.gameObject.GetComponent<bill>();
        restart = GameObject.Find("RE");
        restart.SetActive(false);
        WAVE.SetActive(false);
        town = GameObject.Find("town").GetComponent<SpriteRenderer>();
        //text = GetComponent<Text>();
    }


    void Update()
    {
        test = zombie_kol;
        test1 = bill_icon.position.x;
        //test1 = fill * 340f;
        bar.fillAmount = fill;
        //text.text = wave.ToString();
        //SpawnPoint();
        //Zombies();
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
            //yield return new WaitForSeconds(spawn_time);
            Zombies();
            SpawnPoint();
            Instantiate(zombie,spawn_point.position,transform.rotation);
            zombie_kol++;
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
        for(int j = 0; j < l; j++)
        {
            if (zombie_value < zombie_chance[j])
            {
                zombie = zombie_arr[j];
                break;
            }
        }
    }
    public int wave_time;
    IEnumerator Wave()
    {
        a = 0;
        while (a < 1)
        {
            yield return new WaitForSeconds(0.01f);
            fill += (0.01f / wave_time);
            bill_icon.anchoredPosition = new Vector2(-9+fill*340, bill_icon.anchoredPosition.y);
            if (fill >= 1)
            {
                fill = 1f;
                a = 1;
            }
        }
        if (a == 1)
        {
            wave_img.victory = true;
            StopCoroutine(Spawn());
        }
    }
    public void ChangeChance()
    {
        if (wave == 1)
        {
            zombie_arr[0] = default_zombie; zombie_arr[1] = karl_zombie;
            zombie_chance[0] = 68;zombie_chance[1] = 100;
            spawn_time = 3f;
            wave_time = 90;
            town.sprite = town_1;
            bestiary.zomb_kol = 2;//bestiary.Chek_zombies();
        }
        else if (wave == 2)
        {
            wave_time = 126;
            zombie_arr[0] = default_zombie; zombie_arr[1] = karl_zombie;
            zombie_chance[0] = 62; zombie_chance[1] = 100;
            spawn_time = 3.13f;
            town.sprite = town_3;
            bestiary.zomb_kol = 3; //bestiary.Chek_zombies();
        }
        else if (wave == 3)
        {
            l = 3;
            spawn_time = 2.35f;
            wave_time = 132;
            zombie_arr = new GameObject[3];
            zombie_arr[0] = default_zombie; zombie_arr[1] = karl_zombie; zombie_arr[2] = bibo_zombie;
            zombie_chance = new int[3];
            zombie_chance[0] = 40; zombie_chance[1] = 70;zombie_chance[2] =100;
            town.sprite = town_2;
            bestiary.zomb_kol = 4;// bestiary.Chek_zombies();
        }
        else if (wave == 4)
        {
            l = 3;
            spawn_time = 2.3f;
            wave_time = 138;
            zombie_arr = new GameObject[3];
            zombie_arr[0] = lara_zombie; zombie_arr[1] = karl_zombie; zombie_arr[2]=bibo_zombie;
            zombie_chance = new int[3];
            zombie_chance[0] =25;zombie_chance[1]=75; zombie_chance[2] = 100;
            town.sprite = town_1;
            bestiary.zomb_kol = 5;// bestiary.Chek_zombies();
            /*l = 1;
            spawn_time = 100f;
            wave_time = 132;
            zombie_arr = new GameObject[1];
            zombie_arr[0] = lara_zombie;
            zombie_chance = new int[1];
            zombie_chance[0] = 100;
        */
        }
        else if(wave==5)
        {
            l = 1;
            spawn_time = 0.8f;
            wave_time = 80;
            zombie_arr = new GameObject[1];
            zombie_arr[0] = martin_zombie;
            zombie_chance = new int[3];
            zombie_chance[0] = 100;
            town.sprite = town_2;
            bestiary.zomb_kol = 6;//bestiary.Chek_zombies();
        }
        else if (wave == 6)
        {
            l = 2;
            spawn_time = 2.8f;
            wave_time = 100;
            zombie_arr = new GameObject[2];
            zombie_arr[0] = mike_zombie; zombie_arr[1] = lara_zombie;
            zombie_chance = new int[2];
            zombie_chance[0] = 40; zombie_chance[1] = 100;
            town.sprite = town_3;
            bestiary.zomb_kol = 7; //bestiary.Chek_zombies();
        }
        else if (wave == 7)
        {
            l = 3;
            spawn_time = 3.35f;
            wave_time = 150;
            zombie_arr = new GameObject[3];
            zombie_arr[0] = mike_zombie; zombie_arr[1] = lara_zombie;zombie_arr[2] = default_zombie;
            zombie_chance = new int[3];
            zombie_chance[0] = 35;zombie_chance[1] = 70; zombie_chance[2] = 100;
            town.sprite = town_1;
        }
        else if (wave == 8)
        {
            l = 3;
            spawn_time = 3.13f;
            wave_time = 150;
            zombie_arr = new GameObject[3];
            zombie_arr[0] = mike_zombie; zombie_arr[1] = bibo_zombie; zombie_arr[2] = default_zombie;
            zombie_chance = new int[3];
            zombie_chance[0] = 20; zombie_chance[1] = 60; zombie_chance[2] = 100;
            town.sprite = town_2;
        }
        else if (wave == 9)
        {
            l = 3;
            spawn_time = 2.3f;
            wave_time = 162;
            zombie_arr = new GameObject[3];
            zombie_arr[0] = bo_zombie; zombie_arr[1] = bibo_zombie; zombie_arr[2] = default_zombie;
            zombie_chance = new int[3];
            zombie_chance[0] = 33; zombie_chance[1] = 66; zombie_chance[2] = 100;
            town.sprite = town_1;
            bestiary.zomb_kol = 8; //bestiary.Chek_zombies();
        }
        else if (wave == 10)
        {
            l = 7;
            spawn_time = 2.7f;
            wave_time = 150;
            zombie_arr = new GameObject[7];
            zombie_arr[0] = mike_zombie; zombie_arr[1] = lara_zombie; zombie_arr[2] = default_zombie;zombie_arr[3] = bo_zombie;zombie_arr[4] = bibo_zombie;zombie_arr[5] = martin_zombie;zombie_arr[6] = karl_zombie;
            zombie_chance = new int[7];
            zombie_chance[0] = 10; zombie_chance[1] = 27; zombie_chance[2] =49 ; zombie_chance[3] = 59; zombie_chance[4] = 74; zombie_chance[5] =84 ; zombie_chance[6] =100 ;
            town.sprite = town_2;
        }
        else if (wave == 0)
        {
            l = 1;
            spawn_time = 150f;
            wave_time = 150;
            zombie_arr = new GameObject[1];
            zombie_arr[0] = boss;
            zombie_chance = new int[1];
            zombie_chance[0] = 100;
            town.sprite = town_3;
        }
    }
}
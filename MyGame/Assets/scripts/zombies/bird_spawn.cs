using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird_spawn : MonoBehaviour
{
    public GameObject bird,boom_bird,now_bird;
    private GameObject[] bird_arr;
    private int[] bird_chance;

    public Transform spawn_point_1;
    private Transform spawn_point;
    public Transform spawn_point_2;
    private int l;
    private spawn script;
    private float spawn_time;
    public static bool start;
    private bool chek;
    void Start()
    {
        chek = false;
        start = false;
        ChangeChance();
        script = GetComponent<spawn>();
    }

    // Update is called once per frame
    void Update()
    {
        if (start == true&&chek==true)
        {
            start = false;
            StartCoroutine(Spawn());
            StartCoroutine(Wave());
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
    void Birds()
    {
        int bird_value = Random.Range(0, 100);
        for (int j = 0; j < l; j++)
        {
            if (bird_value < bird_chance[j])
            {
                now_bird = bird_arr[j];
                break;
            }
        }
    }
    public static int a;
    IEnumerator Spawn()
    {
        a = 0;
        while (a < 1)
        {
            yield return new WaitForSeconds(spawn_time);
            Birds();
            SpawnPoint();
            Instantiate(now_bird, spawn_point.position, transform.rotation);
            spawn.zombie_kol++;
        }

    }
    IEnumerator Wave()
    {
        a = 0;
        while (a < 1)
        {
            yield return new WaitForSeconds(0.01f);
            if (script.fill >= 1)
            {
                a = 1;
            }
        }
        if (a == 2)
        {
            StopCoroutine(Spawn());
        }
    }
    public void ChangeChance()
    {
        /*if (spawn.wave == 1)
        {
            chek = true;
            l = 2;
            bird_arr = new GameObject[2]; bird_arr[0] = bird; bird_arr[1] = boom_bird;
            bird_chance = new int[2]; bird_chance[0] = 50; bird_chance[1] = 100;
            spawn_time = 6.4f;
        }*/
        if (spawn.wave == 2)
        {
            chek = true;
            l = 1;
            bird_arr = new GameObject[1]; bird_arr[0] = bird;
            bird_chance = new int[1]; bird_chance[0] = 100;
            spawn_time = 9.4f;
        }
        else if (spawn.wave == 5)
        {
            chek = true;
            l = 1;
            bird_arr = new GameObject[1]; bird_arr[0] = boom_bird;
            bird_chance = new int[1]; bird_chance[0] = 100;
            spawn_time = 7.8f;
        }
        /*else if (spawn.wave == 7)
        {
            chek = true;
            l = 1;
            bird_arr = new GameObject[1]; bird_arr[0] = bird;
            bird_chance = new int[1]; bird_chance[0] = 100;
            spawn_time = 7.8f;
        }*/
        else if (spawn.wave == 8)
        {
            chek = true;
            l = 1;
            bird_arr = new GameObject[1]; bird_arr[0] = bird;
            bird_chance = new int[1]; bird_chance[0] = 100;
            spawn_time = 9.4f;
        }
        else if (spawn.wave == 10)
        {
            chek = true;
            l = 1;
            bird_arr = new GameObject[1]; bird_arr[0] = bird;
            bird_chance = new int[1]; bird_chance[0] = 100;
            spawn_time = 18f;
        }
        else if (spawn.wave == 13)
        {
            chek = true;
            l = 1;
            bird_arr = new GameObject[1]; bird_arr[0] = boom_bird;
            bird_chance = new int[1]; bird_chance[0] = 100;
            spawn_time = 8f;
        }
        else if (spawn.wave == 19)
        {
            chek = true;
            l = 1;
            bird_arr = new GameObject[1]; bird_arr[0] = bird;
            bird_chance = new int[1]; bird_chance[0] = 100;
            spawn_time = 8f;
        }
        else
        {
            chek = false;
        }
    }
}

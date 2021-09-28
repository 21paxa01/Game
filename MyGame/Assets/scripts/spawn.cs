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
    private GameObject zombie;
    public Transform spawn_point_1;
    private Transform spawn_point;
    public Transform spawn_point_2;

    private float fill;
    private float zomb_koll = 0f;
    public float max_zomb_koll;
    public Image bar;

    

    Coroutine spawn_zombie;
    public float spawn_time;
    public int i;
    
    void Start()
    {
        fill = 0f;
    }


    void Update()
    {
        bar.fillAmount = fill;
        SpawnPoint();
        Zombies();
       
    }
    private int b = 0;
    public void spawn_zombies()
    {
        a = 0;
        if (b < 1)
        {
           // spawn_zombie = StartCoroutine(Spawn());
        }
        b = 2;
    }
    public int a = 0;
    IEnumerator Spawn()
    {

        while (a<1)
        {
            Instantiate(zombie,spawn_point.position,transform.rotation);
            zomb_koll++;
            fill = zomb_koll / max_zomb_koll;
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
        int zombie_value = Random.Range(0, 1290);
        if (zombie_value<10)
        {
            zombie = bo_zombie;
            
        }
        else if(zombie_value>=10&&zombie_value<25)
        {
            zombie =bibo_zombie;
        }
        else if (zombie_value >= 25 && zombie_value < 40)
        {
            zombie = karl_zombie;
        }
        else if (zombie_value >= 40 && zombie_value < 1290)
        {
            zombie = lara_zombie;
        }
        else if (zombie_value >= 55 && zombie_value < 85)
        {
            zombie = martin_zombie;
        }
        else
        {
            zombie = default_zombie;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave_img : MonoBehaviour
{
    public Animator anim;
    public GameObject vic_img;
    public GameObject wave;
    public GameObject WavE;
    public GameObject RE;
    public static bool victory;
    public GameObject wave_1;
    public GameObject wave_2;
    public GameObject wave_3;
    public GameObject wave_4;
    public GameObject wave_5;
    public GameObject wave_6;
    public GameObject wave_7;
    public GameObject wave_8;
    public GameObject wave_9;
    public GameObject wave_10;
    private GameObject[] waves;
    void Start()
    {
        waves = new GameObject[10];
        waves[0] = wave_1; waves[1] = wave_2; waves[2] = wave_3; waves[3] = wave_4; waves[4] = wave_5; waves[5] = wave_6; waves[6] = wave_7; waves[7] = wave_8; waves[8] = wave_9; waves[9] = wave_10;
        anim = wave.GetComponent<Animator>();
    }

    void Update()
    {
        if (victory == true&&spawn.zombie_kol==0&&bird_spawn.bird_kol==0)
        {
            WavE.SetActive(true);
            vic_img.SetActive(true);
            RE.SetActive(true);
        }
        else
        {
            vic_img.SetActive(false);
        }
    }
    public void Wave()
    {
        StartCoroutine(WaveCount());
    }
    IEnumerator WaveCount()
    {
        wave.SetActive(true);
        waves[spawn.wave - 1].SetActive(true);
        yield return new WaitForSeconds(3.1f);
        waves[spawn.wave - 1].SetActive(false);
        yield return new WaitForSeconds(1.3f);
        wave.SetActive(false);
    }
}

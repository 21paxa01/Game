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
    public GameObject wave_0, wave_1, wave_2, wave_3, wave_4, wave_5, wave_6, wave_7, wave_8, wave_9, wave_10, wave_11, wave_12, wave_13, wave_14, wave_15, wave_16, wave_17, wave_18, wave_19,wave_20,wave_21;
    private GameObject[] waves;
    void Start()
    {
        waves = new GameObject[22];
        waves[0]=wave_0; waves[1] = wave_1; waves[2] = wave_2; waves[3] = wave_3; waves[4] = wave_4; waves[5] = wave_5; waves[6] = wave_6; waves[7] = wave_7; waves[8] = wave_8; waves[9] = wave_9; waves[10] = wave_10;waves[11] = wave_11;waves[12] = wave_12;waves[13] = wave_13;waves[14] = wave_14;waves[15] = wave_15;waves[16] = wave_16; waves[17] = wave_17; waves[18] = wave_18; waves[19] = wave_19;waves[20] = wave_20;waves[21] = wave_21;
        anim = wave.GetComponent<Animator>();
    }

    void Update()
    {
        if (victory == true&&spawn.zombie_kol==0)
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
        waves[spawn.wave].SetActive(true);
        yield return new WaitForSeconds(3.1f);
        waves[spawn.wave].SetActive(false);
        yield return new WaitForSeconds(1.3f);
        wave.SetActive(false);
    }
}

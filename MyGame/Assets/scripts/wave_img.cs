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
    void Start()
    {
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
        yield return new WaitForSeconds(2.2f);
        wave.SetActive(true);
        yield return new WaitForSeconds(2.2f);
        wave.SetActive(false);
    }
}

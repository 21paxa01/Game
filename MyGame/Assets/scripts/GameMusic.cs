using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    public AudioSource sound;
    public static bool stop = false;
    public bool test;
    void Start()
    {
        stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (stop == true)
            Stop();
        test = stop;
    }
    public void Pause()
    {
        sound.Pause();
    }
    public void Resume()
    {
        stop = false;
        sound.Play();
    }
    void Stop()
    {
        sound.Stop();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    public AudioSource sound_1,sound_2;
    public AudioSource sound;
    public static bool stop = false;
    public bool test;
    public float i;
    private Save save_script;
    void Start()
    {
        stop = false;
        i = 1f;
        save_script = GameObject.Find("save").GetComponent<Save>();
        save_script.Load_settings();
        //sound = sound_1;
    }

    void Update()
    {
        if (stop == true)
            Stop();
        test = stop;
        sound.volume = save_script.save_Music;
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

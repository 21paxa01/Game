using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class death : MonoBehaviour
{
    public GameObject death_menu;
    public AudioSource pause_sound;
    public GameObject restart;

    // Update is called once per frame
    void Update()
    {
        if (bill.HP <= 0f)
        {
            Death();
        }
    }

    public void Restart()
    {
        pause_sound.Play();
        restart.SetActive(true);
        wave_img.victory = false;
        bill.HP = 100f;
        death_menu.SetActive(false);
        SceneManager.LoadScene(1);
        spawn.wave++;
        spawn.a = 0;
        spawn.wave_time += 6;
    }
    public void Death()
    {
        death_menu.SetActive(true);
        GameMusic.stop = true;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public AudioSource pause_sound;
    public GameObject Wave_choice;


    // Update is called once per frame
    void Update()
    {
        
    }
    public void Resume()
    {
        pause_sound.Play();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        if (torgovets.shop == false&&mechanik_shop.lab==false)
        {
            pause_sound.Play();
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
    }
    public void Choice()
    {
        Wave_choice.SetActive(true);
    }
}

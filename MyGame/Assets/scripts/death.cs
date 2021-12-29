using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class death : MonoBehaviour
{
    public GameObject death_menu;
    public AudioSource pause_sound;

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
        SceneManager.LoadScene(1);
    }
    public void Death()
    {
        death_menu.SetActive(true);
        GameMusic.stop = true;

    }
}

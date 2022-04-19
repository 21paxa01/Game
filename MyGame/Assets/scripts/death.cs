using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class death : MonoBehaviour
{
    public GameObject death_menu;
    public AudioSource pause_sound;
    public GameObject restart;
    private string[] anonim_phrases = { "Failure again? So you won't last long...", "Better luck next time! Or not?", "I thought you were a better shot... " };
    public GameObject dead_bill;
    public GameObject dead_anonim;
    private int i;
    private bool chek;
    public GameObject phrases;

    public Text text;

    void Start()
    {
        chek = false;
    }
    void Update()
    {
        if (bill.HP <= 0f&&chek==false)
        {
            chek = true;
            Death();
        }
    }

    public void Restart()
    {
        pause_sound.Play();
        bill.OnRoad = false;
        restart.SetActive(true);
        wave_img.victory = false;
        bill.HP = 100f;
        death_menu.SetActive(false);
        SceneManager.LoadScene(1);
        spawn.a = 0;
        chek = false;
    }
    public void Death()
    {
        i = Random.Range(0, 2);
        if (i == 0)
        {
            dead_bill.SetActive(true);
            dead_anonim.SetActive(false);
        }
        else
        {
            dead_bill.SetActive(false);
            dead_anonim.SetActive(true);
            text = phrases.GetComponent<Text>();
            i = Random.Range(0, 3);
            text.text = anonim_phrases[i];
        }
        death_menu.SetActive(true);
        GameMusic.stop = true;

    }
}

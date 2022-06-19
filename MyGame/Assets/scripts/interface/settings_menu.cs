using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settings_menu : MonoBehaviour
{
    public GameObject menu;
    public Scrollbar Musik;
    public Scrollbar Sounds;
    public AudioSource Music_aud;
    private bool chek;
    private Save save_script;
    void Start()
    {
        chek = false;
        save_script = GameObject.Find("save").GetComponent<Save>();
        save_script.Load_settings();
        Musik.value = save_script.save_Music;
        Sounds.value = save_script.save_Sounds;
    }

    void Update()
    {
        save_script.save_Music = Musik.value;
        save_script.save_Sounds = Sounds.value;
    }
    public void Menu_ON()
    {
        menu.SetActive(true);
        Music_aud = GameObject.Find("GameMusic").GetComponent<AudioSource>();
        chek = true;
    }
    public void Menu_OFF()
    {
        menu.SetActive(false);
        save_script.Save_settings();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop_door : MonoBehaviour
{
    public Animator anim_door;
    public AudioSource shop_door_s;
    public static bool open;
    void Start()
    {
        anim_door = GetComponent<Animator>();
        anim_door.SetBool("off", true);
    }

    void Update()
    {
        if (open == true) {
            anim_door.SetBool("off", false);
            anim_door.SetBool("on", true);
            //shop_door_s.Play();
}
        else {
            anim_door.SetBool("on", false);
            anim_door.SetBool("off", true);
            //shop_door_s.Play();
        }
    }

    
}

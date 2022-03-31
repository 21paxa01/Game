using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class home_door : MonoBehaviour
{
    public Animator anim_door;
    public static bool open;
    void Start()
    {
        anim_door = GetComponent<Animator>();
        open = false;
    }

    void Update()
    {
        if (open == true)
        {
            anim_door.SetBool("off", false);
            anim_door.SetBool("on", true);
        }
        else
        {
            anim_door.SetBool("on", false);
            anim_door.SetBool("off", true);
        }
    }
}
    
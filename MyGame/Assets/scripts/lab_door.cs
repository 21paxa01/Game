using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lab_door : MonoBehaviour
{
    public Animator anim_door;
    public static bool open_door;
    void Start()
    {
        anim_door = GetComponent<Animator>();
        anim_door.SetBool("off", true);
    }

    void Update()
    {
        if (open_door == true)
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

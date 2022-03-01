using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mechanik : MonoBehaviour
{
    public Animator anim_door;
    public static bool down;
    void Start()
    {
        anim_door = GetComponent<Animator>();
        anim_door.SetBool("up", true);
    }

    void Update()
    {
        if (down == true)
        {
            anim_door.SetBool("up", false);
            anim_door.SetBool("down", true);
        }
        else
        {
            anim_door.SetBool("down", false);
            anim_door.SetBool("up", true);
        }
    }


}

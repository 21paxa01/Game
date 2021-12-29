using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public Animator anim_door;
    public Transform bill;
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
        }
        else {
            anim_door.SetBool("on", false);
            anim_door.SetBool("off", true);
        }
    }

    
}

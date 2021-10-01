using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class luk_off : MonoBehaviour
{
    public Animator anim_luk;
    public static bool off_luk = false;
    void Start()
    {
        anim_luk = GetComponent<Animator>();
    }

    void Update()
    {
        anim_luk.SetBool("off", off_luk);
    }
}

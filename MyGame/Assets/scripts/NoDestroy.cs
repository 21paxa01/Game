using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoDestroy : MonoBehaviour
{
    public static bool destroy=false;
    void Awake()
    {
        if (destroy == false)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


}
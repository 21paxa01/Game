using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sparks : MonoBehaviour
{
    void Start()
    {
        Invoke("Destroy", 0.2f);
    }

    void Update()
    {
        
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}

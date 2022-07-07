using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenage_line : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyLine", 0.15f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DestroyLine()
    {
        Destroy(gameObject);
    }
}

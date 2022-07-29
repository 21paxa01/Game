using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heal_effect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("Destroy_HEAL", 0.4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Destroy_HEAL()
    {
        Destroy(gameObject);
    }
}

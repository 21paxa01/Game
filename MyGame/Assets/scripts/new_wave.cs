using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class new_wave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NeW_Wave()
    {
        spawn.wave++;
        spawn.wave_time += 6;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freeze : MonoBehaviour
{
    public float freeze_time;
    void Start()
    {
        
    }
    private zombie_debaffs script;
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("zombie"))
        {
            script = other.GetComponent<zombie_debaffs>();
            script.freeze_time = freeze_time;
            if (script.freeze == false)
                script.start_freeze();
        }
    }
}

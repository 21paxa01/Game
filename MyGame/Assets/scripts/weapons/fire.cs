using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public Collider2D coll;
    private zombie_debaffs debaff;
    public float destroyTime;
    void Start()
    {
        coll = GetComponent<Collider2D>();
        Invoke("DestroyFire", destroyTime);
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("zombie"))
        {
            debaff = other.GetComponent<zombie_debaffs>();
            debaff.start_fire();
            coll.enabled = false;
            coll.enabled = true;
        }
    }
    public void DestroyFire()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoke : MonoBehaviour
{
    public Collider2D coll;
    private zombie_debaffs debaff;
    public float destroyTime;
    public bool test;
    void Start()
    {
        coll = GetComponent<Collider2D>();
        Invoke("DestroySmoke", destroyTime);
        coll.enabled = false;
        coll.enabled = true;
    }

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("zombie"))
        {
            debaff = other.GetComponent<zombie_debaffs>();
            debaff.start_smoke();
            coll.enabled = false;
            coll.enabled = true;
            test = true;
        }
        if(other.name == "room")
        {
            //transform.position = new Vector3(transform.position.x, transform.position.y + 1.05f, transform.position.z);
            coll.enabled = false;
            coll.enabled = true;
            test = true;
        }
    }
    public void DestroySmoke()
    {
        Destroy(gameObject);
    }
}

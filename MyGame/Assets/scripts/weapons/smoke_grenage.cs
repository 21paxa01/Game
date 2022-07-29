using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoke_grenage : MonoBehaviour
{
    public GameObject smoke;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "room" || other.name == "wall(Clone)" || other.name == "Shield")
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            Instantiate(smoke, new Vector3(transform.position.x + 0.143f, transform.position.y + 0.62f, transform.position.z),transform.rotation);
            Instantiate(smoke, new Vector3(transform.position.x + 0.143f, transform.position.y + 0.62f, transform.position.z), transform.rotation);
            Instantiate(smoke, new Vector3(transform.position.x + 0.143f, transform.position.y + 0.62f, transform.position.z), transform.rotation);
        }
    }
}
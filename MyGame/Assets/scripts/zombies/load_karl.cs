using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class load_karl : MonoBehaviour
{
    private Rigidbody2D physik;
    void Start()
    {
        physik = GetComponent<Rigidbody2D>();
    }

    public float speed;
    void Update()
    {
        physik.velocity = new Vector2(+speed, 0);
    }
}

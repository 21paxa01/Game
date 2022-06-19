using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCamera : MonoBehaviour
{
    public static float x, y, z;
    public Transform bill;
    private bill script;
    void Start()
    {
        script = GameObject.Find("Bill").GetComponent<bill>();
        x = 0;
        y = 0;
        z = 0;
    }

    void Update()
    {
        if(script.upStairs==false&&bill.position.y< -3.6f)
            transform.position = new Vector3(bill.position.x+x, bill.position.y+y, bill.position.z+z);   
        else if(bill.position.y>-3.6f)
            transform.position = new Vector3(bill.position.x + x, -3.6f, bill.position.z + z);
    }
}

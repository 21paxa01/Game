using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCamera : MonoBehaviour
{
    public static float x, y, z;
    public Transform bill;
    void Start()
    {
        x = 0;
        y = 0;
        z = 0;
    }

    void Update()
    {
        transform.position = new Vector3(bill.position.x+x, bill.position.y+y, bill.position.z+z);   
    }
}

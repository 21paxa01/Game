using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
    public float zoomMin;
    public float zoomMax;
    void Start()
    {
       
    }

    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroLasPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOneLasPos = touchOne.position - touchOne.deltaPosition;

            float distTouch = (touchZeroLasPos - touchOneLasPos).magnitude;
            float currentDistTouch = (touchZero.position - touchOne.position).magnitude;

            float difference = currentDistTouch - distTouch;
            zoom(difference * 0.01f);
        }     

    }
    void zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomMin, zoomMax);
    }
}

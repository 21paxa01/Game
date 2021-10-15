using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ZoomCamera : MonoBehaviour
{
    public float zoomMin;
    public float zoomMax;
    public CinemachineVirtualCamera cum;
    public Transform bill;
    void Start()
    {
       cum= GetComponent<CinemachineVirtualCamera>();
       cum.m_Lens.OrthographicSize = 1f;
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
            //zoom(difference * 0.01f);
        }
        if (bill.position.y>-2.9f)
            cum.m_Lens.OrthographicSize = 2f;
    }
    void zoom(float increment)
    {
        cum.m_Lens.OrthographicSize = Mathf.Clamp(cum.m_Lens.OrthographicSize - increment, zoomMin, zoomMax);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ZoomCamera : MonoBehaviour
{
    public float zoomMin;
    public float zoomMax;
    public CinemachineVirtualCamera cum;
    public GameObject camObj;
    public CinemachineFreeLook freeLook;
    public CinemachineComposer comp;
    public Transform bill;
    bool jostick_move;
    private int a=0;
    bool joustick_shot;
    public Transform shop_cum;
    public static float zoom;
    void Start()
    {
        cum= GetComponent<CinemachineVirtualCamera>();
        zoom = 0.7f;
    }

    void Update()
    {
        cum.m_Lens.OrthographicSize = zoom;
        if (bill.position.y > -3.1f)
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
                if (jostick_move == false && joustick_shot == false)
                    Zoom(difference * 0.01f);
            }
        }
        
    }
    void Zoom(float increment)
    {
        zoom = Mathf.Clamp(cum.m_Lens.OrthographicSize - increment, zoomMin, zoomMax);
    }
    public void Move_down()
    {
        jostick_move = true;
    }
    public void Move_up()
    {
        jostick_move = false;
    }
    public void Shot_down()
    {
        joustick_shot = true;
    }
    public void Shot_up()
    {
        joustick_shot = false;
    }
}

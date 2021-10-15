using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    public int count;
    public  float hp = 200;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.touchCount > 0 && rapt_menu.GameIsPaused == true)
        {
            Touch touchZero = Input.GetTouch(0);
            transform.position = new Vector2(touchZero.position.x, -3.0816f);
            if (Input.touchCount == 0)
                rapt_menu.GameIsPaused = false;
        }
        count = Input.touchCount;*/
        if (hp <= 0f)
            Destroy(gameObject);
    }
}

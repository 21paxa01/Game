using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wall_hp : MonoBehaviour
{
    public Image bar;
    public Image back;
    public float fill;
    public GameObject Wall;
    private wall script;

    void Start()
    {
        fill = 1f;
        script = Wall.gameObject.GetComponent<wall>();
    }

    
    void Update()
    {
        fill = script.hp / script.HP;
        bar.fillAmount = fill;
        if (fill <= 0)
            Destroy(back);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgrade_button : MonoBehaviour
{
    public mechanik_shop script;
    public GameObject mechanik;
    public int i;
    void Start()
    {
        script = mechanik.GetComponent<mechanik_shop>();
    }

    void Update()
    {
        
    }
    public void Upgrade()
    {
        script.category = i;
    }
}

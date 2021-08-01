using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class change_weapon : MonoBehaviour
{
    public GameObject pistol;
    public GameObject ak47;
    private bool change = false;
    void Start()
    {
        ak47.SetActive(false);
    }

    
    void Update()
    {
        
    }
    public void Change()
    {
        pistol.SetActive(change);
        change = !change;
        ak47.SetActive(change);
    }
}

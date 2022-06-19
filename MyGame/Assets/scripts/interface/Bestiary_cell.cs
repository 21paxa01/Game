using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bestiary_cell : MonoBehaviour
{
    public GameObject bobo;
    public GameObject bibo;
    public GameObject bo;
    public GameObject karl;
    public GameObject bird;
    public GameObject lara;
    public GameObject martin;
    public GameObject mike;
    public GameObject locked;
    public int i;
    public int j;
    public Bestiary script;
    private GameObject[] zombies;
    void Start()
    {
        j = 0;
        zombies = new GameObject[8];
        zombies[0] = bobo; zombies[1] = karl; zombies[2] = bird; zombies[3] = bibo; zombies[4] = lara; zombies[5] = martin; zombies[6] = mike; zombies[7] = bo;
        script = GameObject.Find("Home_Canvas").GetComponent<Bestiary>();
        Update_icon();
    }


    void Update()
    {
        
    }
    public void Update_icon()
    {
        zombies[i + j].SetActive(false);
        j = script.i;
        if (script.chek[i + j] == true)
        {
            locked.SetActive(false);
            zombies[i + j].SetActive(true);
        }
        else
            locked.SetActive(true);
    }
    public void Take_zombie()
    {
        script.Zombie_OFF();
        script.j = i;
        script.Zombie_ON();
    }
}

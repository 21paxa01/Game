using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shoting : MonoBehaviour
{
  
    private int offset;
    public int recoil;
    public AudioSource shot_sound;

    public GameObject zombie;

    public GameObject ammo;
    public Transform shotDir;
    public Joystick joystick;

    private float timeShot;
    public float startTime;
    Coroutine fireFrequency;
    public bool shot;

    public bool faceRight = true;
    void Start()
    {
        
    }
    void Update()
    {

        float rotateZ = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);


        Vector3 LocalScale = Vector3.one;
        if (rotateZ > 90 || rotateZ < -90)
        {
            LocalScale.y = -1f;
           
        }
        else
        {
            LocalScale.y = +1f;

        }
        transform.localScale = LocalScale;

        if(joystick.Vertical==0 && joystick.Horizontal == 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, rotateZ);
        }
  
        
        if(joystick.Vertical == 0 || joystick.Horizontal == 0)
        {
            shot = false;
        }
        
        
        
        
    }
    public int change;
    public int Cons_change;
    public void Change()
    {
        change ++;
        if (change == 4)
            change = 1;
    }
    public void Shot()
    {
        shot = true;

        if (change == Cons_change&&ReloaD==false)
        {
            i = 0;
            StartCoroutine(FireDelay());
        }

        
    }
    public int i = 0;
    public int Reload;
    private int reload = 0;
    public static float ReloadTime=3f;
    public  bool ReloaD;
    IEnumerator FireDelay()
    {
        while (shot==true)
        {
            if (reload < Reload)
            {
                reload += 1;
                offset = Random.Range(-recoil, recoil);
                float rotateZ = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);
                Instantiate(ammo, shotDir.position, transform.rotation);
                shot_sound.Play();
                yield return new WaitForSeconds(startTime);
            }
            else
            {
                ReloaD = true;
                yield return new WaitForSeconds(ReloadTime);
                reload = 0;
                ReloaD = false;
            } 

            if (shot==false&&ReloaD==false)
            {
                shot = false;
            }
            

        }
        
    }
   




}

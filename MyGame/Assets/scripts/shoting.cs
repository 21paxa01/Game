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
    public Transform spawn_point;
    Coroutine spawn_zombie;


    public GameObject ammo;
    public Transform shotDir;
    public Joystick joystick;

    private float timeShot;
    public float startTime;
    Coroutine fireFrequency;
    private bool shot;

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
  
        
        if(joystick.Vertical != 0 || joystick.Horizontal != 0)
        {
            shot = true;
        }
        else
        {
            shot = false;
        }
        if (shot==true)
        {
            i = 0;
            
        }
        
        
    }
    public bool change;
    public void Change()
    {
        change = !change;
    }
    public void Shot()
    {


        if (change == true)
        {
            fireFrequency = StartCoroutine(FireDelay());
        }

        
    }
    public int i = 0;
    public int Reload;
    private int reload = 0;
    public float ReloadTime;
    IEnumerator FireDelay()
    {
        while (i<10)
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
                yield return new WaitForSeconds(ReloadTime);
                reload = 0;
            }
            if (shot==false)
            {
                i=10;
            }
            

        }
        
    }
    IEnumerator ReloaD()
    {
        yield return new WaitForSeconds(ReloadTime);
        reload = 0;
    }




}

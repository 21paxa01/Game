using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie_debaffs : MonoBehaviour
{
    public float freeze_time;
    public bool freeze;
    public bool fire,smoke;
    public float fire_time,smoke_time;
    private float fire_time_def,smoke_time_def;
    public float fire_damage,smoke_damage;
    public zombie_hp script;
    public GameObject heal_effect;
    private bool heal;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    IEnumerator Freeze()
    {
        freeze = true;
        while (freeze_time > 0)
        {
            freeze_time -= 1f;
            yield return new WaitForSeconds(1f);
        }
        freeze = false;
    }
    public void start_freeze()
    {
        StartCoroutine(Freeze());
    }
    public void start_fire()
    {
        fire_time_def = fire_time;
        if(fire==false)
            StartCoroutine(Fire());
    }
    public void start_smoke()
    {
        smoke_time_def = smoke_time;
        if (smoke == false)
            StartCoroutine(Smoke());
    }
    IEnumerator Fire()
    {
        fire = true;
        while (fire_time_def > 0)
        {
            fire_time_def -= 0.5f;
            if (script.death == false)
            {
                if (script.hp + fire_damage > script.HP)
                {
                    script.hp = script.HP;
                }
                else
                    script.hp += fire_damage;
                script.fill = 1 - script.hp / script.HP;
            }
            yield return new WaitForSeconds(0.5f);
        }
        fire = false;
    }
    IEnumerator Smoke()
    {
        smoke = true;
        while (smoke_time_def > 0)
        {
            smoke_time_def -= 0.5f;
            if (script.death == false)
            {
                if (script.hp + smoke_damage > script.HP)
                {
                    script.hp = script.HP;
                }
                else
                    script.hp += smoke_damage;
                script.fill = 1 - script.hp / script.HP;
            }
            yield return new WaitForSeconds(0.5f);
        }
        smoke = false;
    }
    IEnumerator Heal()
    {
        heal = true;
        while (heal == true)
        {
            heal_effect.SetActive(true);
            yield return new WaitForSeconds(0.4f);
            heal_effect.SetActive(false);
            heal = false;
        }
    }
    public void StartHeal()
    {
        StartCoroutine(Heal());
    }
}

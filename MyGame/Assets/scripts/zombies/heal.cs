using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heal : MonoBehaviour
{
    private zombie_hp script;
    private zombie_debaffs deb_script;
    public float Heal;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("zombie"))
        {
            script = other.gameObject.GetComponent<zombie_hp>();
            deb_script= other.gameObject.GetComponent<zombie_debaffs>();
            if (script.death == false)
            {
                deb_script.StartHeal();
                if (script.hp - Heal<0)
                {
                    script.hp =0;
                }
                else
                    script.hp -= Heal;
                script.fill = 1 - script.hp / script.HP;
            }
        }
    }
}

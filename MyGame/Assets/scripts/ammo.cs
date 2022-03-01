using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo : MonoBehaviour
{
    public float speed;
    public float destroyTime;
    public float death_time;
    public bool death;
    public Animator anim;
    private Rigidbody2D rb;
    private zombie_hp script;
    public int ammo_damage;
    public bool road;
    void Start()
    {
        Invoke("DestroyAmmo", destroyTime);
        
    }

    
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void DestroyAmmo()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "room" || other.name == "wall(Clone)" || other.name == "Shield")
        {
            if (road == true)
            {
                Destroy(gameObject);

            }
        }
        if (other.CompareTag("zombie"))
        {
            script = other.gameObject.GetComponent<zombie_hp>();
            if (script.death == false)
            {
                Destroy(gameObject);
                if (script.hp + ammo_damage > script.HP)
                {
                    script.hp = script.HP;
                }
                else
                    script.hp += ammo_damage;
                script.fill = 1 - script.hp / script.HP;
            }
        }
    }
    

}

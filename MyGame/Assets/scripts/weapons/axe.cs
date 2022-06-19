using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axe : MonoBehaviour
{
    public Animator anim;
    public float damage;
    public Joystick joystick;
    private int offset;
    public int const_change;
    private Rigidbody2D rb;
    public float speed;
    public float rotateZ;
    private zombie_hp script;
    public Transform bill;
    public Collider2D coll;
    private bool attack;
    public bool right;
    public bool left;
    public GameObject line;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (change_weapon.change == const_change)
        {
            rotateZ = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;
            transform.position = new Vector3(bill.position.x + 0.012f, bill.position.y + 0.12f, bill.position.z);
            if (rotateZ < 90 && rotateZ > -90)
            {
                right = true; left = false;
            }
            else
            {
                right = false; left = true;
            }
            if (joystick.Vertical != 0 && joystick.Horizontal != 0)
            {
                attack = true;
                anim.SetBool("attack", attack);
                line.SetActive(true);
            }
        }
        if (joystick.Vertical == 0 && joystick.Horizontal == 0)
        {
            line.SetActive(false);
            transform.localRotation = Quaternion.Euler(0, 0, rotateZ);
            attack = false;
            anim.SetBool("attack", attack);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("zombie"))
        {
            script = other.gameObject.GetComponent<zombie_hp>();
            if (right == true) script.kef = 1;
            else script.kef = -1;
            script.discard();
            if (script.death == false)
            {
                if (script.hp + damage > script.HP)
                {
                    script.hp = script.HP;
                }
                else
                    script.hp += damage;
                script.fill = 1 - script.hp / script.HP;
            }
        }
    }
}

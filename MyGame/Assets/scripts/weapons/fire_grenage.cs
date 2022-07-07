using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_grenage : MonoBehaviour
{
    public Animator anim;
    private bool death;
    public float speed;
    public float death_time;
    private Rigidbody2D rb;
    private zombie_hp script;
    public float damage;
    private Collider2D coll;
    public float reload_time;
    public GameObject line;
    private SpriteRenderer sprite;
    public float rotate_distance;
    private float rotate_y;
    private float rotate_z;
    private float kef;
    public GameObject fire;
    private float fire_rad;
    private float col;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "room" || other.name == "wall(Clone)" || other.name == "Shield")
        {
            if (death == false)
            {
                sprite.color = new Color(1f, 1f, 1f, 0f);
                sprite = fire.GetComponent<SpriteRenderer>();
                transform.position = new Vector3(transform.position.x, -3.08f, transform.position.z);
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                StartCoroutine(FireSpawn());
            }
        }
    }
    IEnumerator FireSpawn()
    {
        col = 1f;
        sprite.color = new Color(1f, 1f, 1f, col);
        Instantiate(fire, transform.position, transform.rotation);
        for (int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(0.02f);
            fire_rad += 0.21f;
            col -= 0.06f;
            sprite.color = new Color(1f, 1f, 1f, col);
            Instantiate(fire, new Vector3(transform.position.x + fire_rad, transform.position.y, transform.position.z), transform.rotation);
            Instantiate(fire, new Vector3(transform.position.x - fire_rad, transform.position.y, transform.position.z), transform.rotation);
        }
    }
}

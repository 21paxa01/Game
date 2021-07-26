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
        if (other.name == "road u")
        {
            StartCoroutine(Die());
        }
    }
    IEnumerator Die()
    {
        speed = 0;
        death = true;
        anim.SetBool("death", death);
        yield return new WaitForSeconds(death_time);
        Destroy(gameObject);
        
    }

}

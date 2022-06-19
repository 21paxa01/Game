using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyMagnet : MonoBehaviour
{
    public GameObject player;
    public float distToPlayer;
    private float kef_x;
    private float kef_y;
    private int kef;
    public float speed;
    public bool chek;
    public Rigidbody2D physik;
    void Start()
    {
        chek = false;
        physik = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Bill");
    }

    void Update()
    {
        distToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (player.transform.position.x > transform.position.x)
            kef = -1;
        else
            kef = 1;
        kef_x = Mathf.Abs(transform.position.x - player.transform.position.x);
        kef_y = Mathf.Abs(transform.position.y - (player.transform.position.y + 0.15f));
        if (distToPlayer<2f&&chek==false)
        {
            chek = true;
        }
        if (chek == true)
        {
            if (player.transform.position.x < transform.position.x && player.transform.position.y + 0.15f < transform.position.y)
            {
                physik.velocity = new Vector2(-speed, (-speed) / (kef_x / kef_y));
                transform.localScale = new Vector2(1, 1);
            }
            else if (player.transform.position.x > transform.position.x && player.transform.position.y + 0.15f < transform.position.y)
            {
                physik.velocity = new Vector2(+speed, (-speed) / (kef_x / kef_y));
                transform.localScale = new Vector2(-1, 1);
            }
            if (player.transform.position.x < transform.position.x && player.transform.position.y + 0.15f > transform.position.y)
            {
                physik.velocity = new Vector2(-speed, (speed) / (kef_x / kef_y));
                transform.localScale = new Vector2(1, 1);
            }
            else if (player.transform.position.x > transform.position.x && player.transform.position.y + 0.15f > transform.position.y)
            {
                physik.velocity = new Vector2(+speed, (speed) / (kef_x / kef_y));
                transform.localScale = new Vector2(-1, 1);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    private Collider2D coll;
    [SerializeField] private LayerMask ground;

    void Start()
    {
        coll = GetComponent<Collider2D>();
        rb.velocity = transform.right * speed;
    }
       
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.JumpedOn();
            Destroy(gameObject);
        }else if (other.gameObject.tag == "EnemyBoss")
        {
            Boss enemy = other.gameObject.GetComponent<Boss>();
            enemy.JumpedOn();
            Destroy(gameObject);
        }
        else if (coll.IsTouchingLayers(ground))
        {
            Destroy(gameObject);
        }
    }
}

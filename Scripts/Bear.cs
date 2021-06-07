using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : Enemy
{
    [SerializeField] private float rightCap;
    [SerializeField] private float leftCap;


    [SerializeField] private LayerMask ground;
    private Collider2D coll;  


    private bool facingLeft = true;

    protected override void Start()
    {
        base.Start();
        coll = GetComponent<Collider2D>();
         
    }

    private void Update()
    {
        Move();
        //if (anim.GetBool("Walking"))
        //{
        //    if (rb.velocity.y < .1)
        //    {
        //        anim.SetBool("Walking", false);
        //    }
        //}
    }

    private void Move()
    {
        if (facingLeft)
        {
            if (transform.position.x > leftCap)
            {
                if (transform.localScale.x != 1)
                {
                    transform.localScale = new Vector2(1, 1);
                    // transform.localScale = new Vector3(1, 1, 1);
                }
                transform.Translate(-1* Time.deltaTime *2,0,0);
                // rb.velocity = new Vector2(jumpLength, rb.velocity.y);
                anim.SetBool("Walking", true);                
            }
            else
            {
                facingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < rightCap)
            {
                if (transform.localScale.x != -1)
                {
                    transform.localScale = new Vector2(-1, 1);
                    //transform.localScale = new Vector3(-1, 1);
                }
                transform.Translate(1 * Time.deltaTime * 2, 0, 0);
                // rb.velocity = new Vector2(jumpLength, rb.velocity.y);
                anim.SetBool("Walking", true);
                
            }
            else
            {
                facingLeft = true;
            }
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    [SerializeField] private float rightCap;
    [SerializeField] private float leftCap;

    [SerializeField] private float jumpLength = 5f;
    [SerializeField] private float jumpHeight = 5f;
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
        if (anim.GetBool("Walking"))
        {
            if (rb.velocity.y < .1)
            {
                anim.SetBool("Walking", false);
            }
        }
    }

    private void Move()
    {
        if (facingLeft)
        {
            if (transform.position.x > leftCap)
            {
                if (transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }

                if (coll.IsTouchingLayers(ground))
                {
                    rb.velocity = new Vector2(-jumpLength, jumpHeight);
                    anim.SetBool("Walking",true);
                }
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
                    transform.localScale = new Vector3(-1, 1);
                }

                if (coll.IsTouchingLayers(ground))
                {
                    rb.velocity = new Vector2(jumpLength, jumpHeight);
                    anim.SetBool("Walking", true);
                }
            }
            else
            {
                facingLeft = true;
            }
        }
    }

}

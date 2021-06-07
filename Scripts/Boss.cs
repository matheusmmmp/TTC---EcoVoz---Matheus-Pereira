using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private float rightCap;
    [SerializeField] private float leftCap;
    [SerializeField] private LayerMask ground;
    [SerializeField] private GameObject shield;

    private Collider2D coll;
    private bool activePower = false;
    private bool facingLeft = true;
    private Animator anim;
    private Rigidbody2D rb;
    private AudioSource death;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        death = GetComponent<AudioSource>();       
        coll = GetComponent<Collider2D>();
    }

    private void Update()
    {
        Move();
    
        if (activePower)
        {
            StartCoroutine(ResetPower());
        }
        else
        {
            StartCoroutine(GetPower());
        }
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
                transform.Translate(-2 * Time.deltaTime * 1, 0, 0);
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
                transform.Translate(2 * Time.deltaTime * 1, 0, 0);
                // rb.velocity = new Vector2(jumpLength, rb.velocity.y);
                anim.SetBool("Walking", true);
            }
            else
            {
                facingLeft = true;
            }
        }
    }

    private IEnumerator GetPower()
    {
        yield return new WaitForSeconds(1);
        int xcount = Random.Range(1, 15);
        if (xcount == 4)
        {
            shield.SetActive(true);
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else
        {
            activePower = true;
        }
    }
    private IEnumerator ResetPower()
    {
        yield return new WaitForSeconds(1);
        shield.SetActive(false);
        activePower = false;
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void JumpedOn()
    {
        if (!activePower)
        {
            death.Play();
            anim.SetTrigger("Death");
            rb.velocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Kinematic;
            GetComponent<Collider2D>().enabled = false;
        }           
    }

    private void Death()
    {
        Destroy(this.gameObject);
    }

}

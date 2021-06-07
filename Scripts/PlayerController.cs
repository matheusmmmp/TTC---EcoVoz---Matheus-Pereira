using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;
using System.Reflection;
using System.Threading;
using System.Text.RegularExpressions;

public class PlayerController : MonoBehaviour
{
    //Start() Variables
    private Rigidbody2D rb;
    private Weapon wp;
    private Animator anim;
    public Text txt;
    private Collider2D coll;
    float horizontalMove = 0f;
    float move = 0f;
    //FDM
    private enum State {idle, running, jumping, falling, hurt}
    private State state = State.idle;

    //Inspector Variables
    public bool powerUp = false;
    [SerializeField] private LayerMask ground;
    private float speed;
    [SerializeField] private float jumpForce = 10f;
   
    [SerializeField] private float hurtForce = 10f;
    [SerializeField] private AudioSource cherry;
    [SerializeField] private AudioSource footstep;
    private bool m_FacingRight = true;
    private PauseMenu goScript;
    private lblCommand goText;
    private bool controlGame = true;

    private void Start()
    {
        wp = GetComponent<Weapon>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        PermanentUI.perm.healthAmount.text = PermanentUI.perm.health.ToString();
        transform.position = PermanentUI.perm.lastCheckPointPos;
        goScript = (PauseMenu)GameObject.Find("Canvas").GetComponent(typeof(PauseMenu));
        goText = (lblCommand)GameObject.Find("command").GetComponent(typeof(lblCommand));

        if (PermanentUI.perm.control == 1)
        {
            controlGame = false;
        }

        if (controlGame)
        {
            speed = 4.5f;
        }
        else
        {
            speed = 11;
        }
    }

    void Update()
    {        
        if (state != State.hurt)
        {
            if (controlGame)
            {
                MovimentKey();                
            }
            else
            {
                MovimentVoice();
            }           
        }            
        AnimationState();
        anim.SetInteger("state", (int)state);
    }

    private void MovimentKey()
    {
        float hDirection = Input.GetAxis("Horizontal");
        //Left
        if (hDirection < 0)
        {           
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            // transform.localScale = new Vector2(-1, 1);
            if (m_FacingRight)
            {
                Flip();
            }
        }
        //Right
        else if (hDirection > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            //transform.localScale = new Vector2(1, 1);
            if (!m_FacingRight)
            {
                Flip();
            }
        }
        //Jumping
        if ((Input.GetButtonDown("Jump") || Input.GetKey("joystick button 2")) && coll.IsTouchingLayers(ground))
        {
            Jump();       
        }

        if ((Input.GetButtonDown("Fire1")) && powerUp)
        {
            StartCoroutine(wp.Shoot());                      
        }       
    }

    private void MovimentVoice()
    {
        //if (((String.CompareOrdinal("top", txt.text) == 0) || (String.CompareOrdinal("toque", txt.text) == 0)) && coll.IsTouchingLayers(ground))
        //if ((txt.text.Contains("top") || txt.text.Contains("toque")) && coll.IsTouchingLayers(ground))
        //if ((!CustomStartsWith("top", txt.text)  || !CustomStartsWith("toque", txt.text)) && coll.IsTouchingLayers(ground))
        //if ((txt.text.StartsWith("top", StringComparison.Ordinal)  || txt.text.StartsWith("toque", StringComparison.Ordinal)) && coll.IsTouchingLayers(ground))
        //if ((String.Equals("top", txt.text)  || String.Equals("toque", txt.text)) && coll.IsTouchingLayers(ground))
        //if ((txt.text.Equals("top", StringComparison.Ordinal) || txt.text.Equals("toque", StringComparison.Ordinal)) && coll.IsTouchingLayers(ground))
        //if (Regex.IsMatch(txt.text, "top", RegexOptions.IgnoreCase) && coll.IsTouchingLayers(ground) ||  Regex.IsMatch(txt.text, "toque", RegexOptions.IgnoreCase) && coll.IsTouchingLayers(ground))
        //if ((!CustomEndsWith("top", txt.text) || !CustomEndsWith("toque", txt.text)) && coll.IsTouchingLayers(ground))
        // if (Regex.Match(txt.text, "top").Success && coll.IsTouchingLayers(ground) ||  Regex.Match(txt.text, "toque").Success && coll.IsTouchingLayers(ground))

        //if (txt.text.Length <= 5)
        //{
        //    if ((txt.text.Contains("pula") || txt.text.Contains("bula") || txt.text.Contains("Olá") || txt.text.Contains("Lula") || txt.text.Contains("pular") || txt.text.Contains("pulo") || txt.text.Contains("bulo")) && coll.IsTouchingLayers(ground))
        //    {
        //        StartCoroutine(goText.CommandLbl("Pula!"));                
        //        Jump();
        //    } else if ((txt.text.Contains("poder") || txt.text.Contains("fogo")) && powerUp) {
        //        StartCoroutine(goText.CommandLbl("Poder!"));
        //        StartCoroutine(wp.Shoot());
        //        txt.text = "";
        //    }else
        //    if (txt.text.Contains("fecha"))
        //    {
        //        StartCoroutine(goText.CommandLbl("Fecha!"));
        //        goScript.Resume();
        //    }           
        //    txt.text = "";
        //} else if (txt.text.Length == 7) {
        //   if (txt.text.Contains("direita"))
        //    {
        //        StartCoroutine(goText.CommandLbl("Direita!"));
        //        if (!m_FacingRight)
        //        {
        //            Flip();
        //        }
        //        horizontalMove = 1;
        //    }         
        //    txt.text = "";
        //}else if (txt.text.Length == 8) {
        //    if (txt.text.Contains("esquerda") || txt.text.Contains("isqueiro"))
        //    {
        //        StartCoroutine(goText.CommandLbl("Esquerda!"));
        //        horizontalMove = -1;
        //        if (m_FacingRight)
        //        {
        //            Flip();
        //        }
        //    }        
        //    txt.text = "";
        //}
        //else if (txt.text.Length == 6)
        //{
        //    if (txt.text.Contains("começa"))
        //    {
        //        StartCoroutine(goText.CommandLbl("Começa!"));
        //        goScript.Resume();
        //        horizontalMove = 1;
        //        transform.localScale = new Vector2(1, 1);
        //    }            
        //    txt.text = "";
        //}
        //else if (txt.text.Length == 9)
        //{
        //    if (txt.text.Contains("pula-pula"))
        //    {
        //        StartCoroutine(goText.CommandLbl("Pula!"));
        //        Jump();
        //    }        
        //    txt.text = "";
        //}


        if (txt.text.Contains("magia"))
        {
			StartCoroutine(goText.CommandLbl("Poder!"));
			StartCoroutine(wp.Shoot());
			txt.text = "";
		}


		txt.text = "";
        move = horizontalMove * Time.fixedDeltaTime* speed;
        rb.velocity = new Vector2(move * 10f, rb.velocity.y);
    }  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collectable")
        {
            cherry.Play();
            Destroy(collision.gameObject);
            PermanentUI.perm.cherries += 1;
            PermanentUI.perm.collectableNumber.text = PermanentUI.perm.cherries.ToString();
        }else 
        if (collision.tag == "Powerup")
        {         
            Destroy(collision.gameObject);
            jumpForce = 15f;
            GetComponent<SpriteRenderer>().color = Color.yellow;
            StartCoroutine(ResetPower());
        }
        else
        if (collision.tag == "Powerup2")
        {
            Destroy(collision.gameObject);
            powerUp = true;
        }
        else
        if (collision.tag == "Trap")
        {
            rb.velocity = new Vector2(-hurtForce, 12);
            state = State.hurt;
            HandleHealth();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();

            if (state == State.falling)
            {
                enemy.JumpedOn();
                Jump();
            }
            else
            {
                state = State.hurt;
                HandleHealth();
                if (other.gameObject.transform.position.x > transform.position.x)
                {
                    rb.velocity = new Vector2(-hurtForce, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(hurtForce, rb.velocity.y);
                }                   
            }
        }else if (other.gameObject.tag == "EnemyBoss")
        {
            Boss enemy = other.gameObject.GetComponent<Boss>();

            if (state == State.falling)
            {
                enemy.JumpedOn();
                Jump();
            }
            else
            {
                state = State.hurt;
                HandleHealth();
                if (other.gameObject.transform.position.x > transform.position.x)
                {
                    rb.velocity = new Vector2(-hurtForce, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(hurtForce, rb.velocity.y);
                }
            }
        }
    }

    private void HandleHealth()
    {
        PermanentUI.perm.health -= 1;
        PermanentUI.perm.healthAmount.text = PermanentUI.perm.health.ToString();
        if (PermanentUI.perm.health <= 0)
        {
           // PermanentUI.perm.tentativas = PermanentUI.perm.tentativas + 1;
            PermanentUI.perm.firstTime = false;
            PermanentUI.perm.Reset();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
           // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void AnimationState()
    {
        if(state == State.jumping)
        {
            if (rb.velocity.y < .1f)
            {
                state = State.falling;
            }
        }
        else if (state == State.falling)
        {
            if (coll.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
        }
        else if (state == State.hurt)
        {
            if (Mathf.Abs(rb.velocity.x) < .1f)
            {
                state = State.idle;
            }
        }
        else if (Mathf.Abs(rb.velocity.x) > 2f)
        {
            state = State.running;
        }
        else 
        {
            state = State.idle;
        }

    }
    
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        state = State.jumping;
    }

    public static bool CustomStartsWith(string a, string b)
    {
        int aLen = a.Length;
        int bLen = b.Length;

        int ap = 0; int bp = 0;

        while (ap < aLen && bp < bLen && a[ap] == b[bp])
        {
            ap++;
            bp++;
        }

        return (bp == bLen);
    }

    public static bool CustomEndsWith(string a, string b)
    {
        int ap = a.Length - 1;
        int bp = b.Length - 1;

        while (ap >= 0 && bp >= 0 && a[ap] == b[bp])
        {
            ap--;
            bp--;
        }

        return (bp < 0);
    }

    private void Footstep()
    {
        footstep.Play();
    }

    private IEnumerator ResetPower()
    {
        yield return new WaitForSeconds(10);
        jumpForce = 10;
        GetComponent<SpriteRenderer>().color = Color.white;
    }


    private void Flip()
    {
        m_FacingRight = !m_FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}

//if (string.Equals("left", txt.text))
//{
//    rb.velocity = new Vector2(-5, rb.velocity.y);
//}
//if (string.Equals("right", txt.text))
//{
//    rb.velocity = new Vector2(5, rb.velocity.y);
//}

//if (txt.text.Equals("right", StringComparison.Ordinal))
//{
//    rb.velocity = new Vector2(5, rb.velocity.y);
//}

//if (txt.text.Equals("left", StringComparison.Ordinal))
//{
//    rb.velocity = new Vector2(-5, rb.velocity.y);
//}

//if (txt.text.Contains("left", StringComparison.OrdinalIgnoreCase))
//{
//    rb.velocity = new Vector2(-5, rb.velocity.y);
//}
//if (txt.text.Contains("right", StringComparison.OrdinalIgnoreCase))
//{
//    rb.velocity = new Vector2(5, rb.velocity.y);
//}


//---TESTADO

//if (txt.text.StartsWith("right"))
//{
//    rb.velocity = new Vector2(5, rb.velocity.y);
//}

//if (txt.text.StartsWith("left"))
//{
//    rb.velocity = new Vector2(-5, rb.velocity.y);
//}
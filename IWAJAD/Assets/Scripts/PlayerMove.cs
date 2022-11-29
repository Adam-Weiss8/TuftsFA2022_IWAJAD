using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //walk variables
    private float walkInput;
    public float walksp;

    //jump variables
    private float jumpInput;
    public float jumpHeight;
    private bool canJump;
    public float wallJumpX;
    public float wallJumpY;

    //dash variables
    public float dashSpeed;
    public bool canDash;

    //player rigidbody
    private Rigidbody2D rb;

    //Animation
    public Animator anim;

    //Grapple
    public GameObject grappleHook;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        canJump = true;
        canDash = true;
    }

   
    void Update()
    {
        
        //check for input
        walkInput = Input.GetAxis("Horizontal");
        jumpInput = Input.GetAxis("Jump");

        //flip player scale and direction
        if (walkInput > 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            grappleHook.transform.localScale = new Vector3(1, 1, 1);
        } else if (walkInput < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            grappleHook.transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && canDash)
        {
            Dash();
        }

        //handle gravity based on if the player is rising or falling
        if(rb.velocity.y < 0)
        {
            rb.gravityScale = 1.5f;
        } else
        {
            rb.gravityScale = 1;
        }

        


    }

    private void FixedUpdate()
    {
        if (walkInput != 0)
        {
            anim.SetTrigger("run");
            rb.velocity = new Vector2(walkInput * walksp, rb.velocity.y);
        } else if(jumpInput == 0)
        {
            anim.SetTrigger("idle");
        }

        if (canJump && jumpInput == 1) {
            anim.SetTrigger("jump");
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            canJump = false;
        }

        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground")) {
            canJump = true;
            
            canDash = true;
            anim.SetTrigger("idle");
        }

        if (collision.gameObject.CompareTag("wall"))
        {
            //wall jump
            if(Input.GetAxisRaw("Jump") == 1 && walkInput != 0)
            {
                rb.AddForce(new Vector2(wallJumpX * -walkInput, wallJumpY), ForceMode2D.Impulse);
            }

            if (walkInput != 0)
            {
                if (rb.velocity.y < -0.5)
                {
                    rb.velocity = new Vector2(rb.velocity.x, -0.5f);
                }
            }
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            rb.gravityScale = 1;
        }
    }

    private void Dash()
    {

        /*
        Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 heading = target - rb.position;
        Vector2 direction = heading / heading.magnitude;
        Vector2 directionx = new Vector2(direction.x, 0);
        Vector2 directiony = new Vector2(0, direction.y);
        rb.AddForce(directionx * dashSpeed, ForceMode2D.Impulse);
        rb.AddForce(directiony * dashSpeed, ForceMode2D.Impulse);

        canDash = false;
        */



    }


}

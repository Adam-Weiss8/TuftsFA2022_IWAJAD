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

    //dash variables
    public float dashSpeed;
    public bool canDash;

    //player rigidbody
    private Rigidbody2D rb;


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
        if (canJump && jumpInput == 1) {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            canJump = false;
        }

        rb.velocity = new Vector2(walkInput * walksp, rb.velocity.y);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground")) {
            canJump = true;
        }
        canDash = true;
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

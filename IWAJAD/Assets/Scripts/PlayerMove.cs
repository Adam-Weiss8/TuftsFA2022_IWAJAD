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

    //player rigidbody
    private Rigidbody2D rb;

    //constants
    public float terminalVelocity;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        canJump = true;
    }

   
    void Update()
    {
        walkInput = Input.GetAxis("Horizontal");
        jumpInput = Input.GetAxis("Jump");

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
        //check terminal velocity
        if (rb.velocity.y < terminalVelocity)
        {
            rb.velocity = new Vector2(0, terminalVelocity);
        } else if (rb.velocity.y > terminalVelocity * -1) {
            rb.velocity = new Vector2(0, -1 * terminalVelocity);
        } else if (canJump) {
            rb.AddForce(jumpInput * Vector2.up * jumpHeight, ForceMode2D.Impulse);
            canJump = false;
        }

        transform.Translate(new Vector2(walkInput * walksp, 0) * Time.deltaTime);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (rb.velocity.y == 0)
        {
        canJump = true;
        }
    }


}

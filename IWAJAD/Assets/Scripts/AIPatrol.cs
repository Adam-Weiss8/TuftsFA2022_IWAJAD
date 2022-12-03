using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    [HideInInspector]
    public bool mustPatrol;
    public Rigidbody2D rb;
    public Transform groundCheckPos;
    private bool mustTurn;
    public LayerMask groundLayer;
    public LayerMask walls;
    public float walkSpeed;
    public Collider2D bodyCollider;

    void Start()
    {
        mustPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (mustPatrol) {
            Patrol();
        }
    }

    void FixedUpdate() {
        if(mustPatrol) {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }

    void Patrol() {
        if (mustTurn || bodyCollider.IsTouchingLayers(walls)) {
            Flip();
        }

        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip() {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }
}

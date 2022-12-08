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
	
	public float groundRange = 0.1f;
    public float walkSpeed;
    public Collider2D bodyCollider;

    void Start()
    {
        mustPatrol = true;
    }


    void FixedUpdate() {
        if(mustPatrol) {
			Patrol();
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, groundRange, groundLayer);
        }
    }

    void Patrol() {
        if ((mustTurn) || (bodyCollider.IsTouchingLayers(walls))) {
            Flip();
        }

        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip() {
        //mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        //mustPatrol = true;
    }
	
	void OnDrawGizmosSelected(){
              Gizmos.DrawWireSphere(groundCheckPos.position, groundRange);
    }
	
	
}

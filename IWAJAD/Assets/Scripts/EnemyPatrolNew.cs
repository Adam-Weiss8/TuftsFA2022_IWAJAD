using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolNew : MonoBehaviour {

	Animator anim;
       public float speed = 2f;
       public Rigidbody2D rb;
       public LayerMask groundLayer;
	   public LayerMask wallLayer;
       public Transform groundCheck;
       bool isFacingRight = false;
       RaycastHit2D hitDown;
	   RaycastHit2D hitFwd;
	   private float dazedTime;
	   public float startDazedTime;
	   public bool hasNotFoundEdge = true;

		private float rayLength = 0.8f;

       void Start(){
			rb = GetComponent<Rigidbody2D>();
       }

	void Update(){
		hitDown = Physics2D.Raycast(groundCheck.position, -transform.up, rayLength, groundLayer);
		hitFwd = Physics2D.Raycast(groundCheck.position, -transform.right, rayLength/2, wallLayer);

		if(dazedTime <= 0) {
			speed = 2f;
		} else {
			speed = 0;
			dazedTime -= Time.deltaTime;
		}	
	}

	public void Knockback() {
		dazedTime = startDazedTime;
	}

	void FixedUpdate(){
		     
		if (hitDown.collider != false){
			hasNotFoundEdge = false;
			if (isFacingRight){
				rb.velocity = new Vector2(speed, rb.velocity.y);
			} else {
				rb.velocity = new Vector2(-speed, rb.velocity.y);
			}
			hasNotFoundEdge = true;
		} else {
			isFacingRight = !isFacingRight;
			transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1f);
		}
		
		//wall flipping
		if (hitFwd.collider != false){
			Debug.Log("I hit a wall: ");
			isFacingRight = !isFacingRight;
			transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1f);   
		}
		
	}
	   
	void OnDrawGizmosSelected(){
              Gizmos.DrawWireSphere(groundCheck.position, rayLength);
			  Gizmos.DrawWireSphere(groundCheck.position, rayLength/2);
    }
	   
}
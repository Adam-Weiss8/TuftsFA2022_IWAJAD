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

       //public int damage = 10;
       //private GameHandler gameHandler;
		private float rayLength = 0.8f;

       void Start(){
			//anim = GetComponent<Animator>();
			rb = GetComponent<Rigidbody2D>();
			//anim.SetBool("Walk", true);
			//if (GameObject.FindWithTag ("GameHandler") != null) {
			//    gameHandler = GameObject.FindWithTag ("GameHandler").GetComponent<GameHandler> ();
			//}
       }

	void Update(){
		hitDown = Physics2D.Raycast(groundCheck.position, -transform.up, rayLength, groundLayer);
		hitFwd = Physics2D.Raycast(groundCheck.position, -transform.right, rayLength/2, wallLayer);
	}

	void FixedUpdate(){
		     
		if (hitDown.collider != false){
			if (isFacingRight){
				rb.velocity = new Vector2(speed, rb.velocity.y);
			} else {
				rb.velocity = new Vector2(-speed, rb.velocity.y);
			}
		} else {
			isFacingRight = !isFacingRight;
			transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
		}
		
		//wall flipping
		if (hitFwd.collider != false){
			Debug.Log("I hit a wall: ");
			isFacingRight = !isFacingRight;
			transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);   
		}
		
	}

	//public void OnCollisionEnter2D(Collision2D other){
              //if (other.gameObject.tag == "Player") {
                     //anim.SetBool("Attack", true);
                     //gameHandlerObj.playerGetHit(damage);
                     //rend.material.color = new Color(2.4f, 0.9f, 0.9f, 0.5f);
                     //StartCoroutine(HitEnemy());
              //}
       //}

       //public void OnCollisionExit2D(Collision2D other){
       //       if (other.gameObject.tag == "Player") {
                     //anim.SetBool("Attack", false);
       //       }
       //}
	   
	void OnDrawGizmosSelected(){
              Gizmos.DrawWireSphere(groundCheck.position, rayLength);
			  Gizmos.DrawWireSphere(groundCheck.position, rayLength/2);
			  //Debug.DrawLine(groundCheck.position, -transform.up, Color.red, rayLength);
			  //Debug.DrawLine(groundCheck.position, -transform.right, Color.red, rayLength/2);
    }
	   
}
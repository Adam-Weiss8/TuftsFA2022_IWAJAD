using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

       public int damage =1;
       public float speed = 10f;
       private Transform playerTrans;
       private Vector2 target;
       public GameObject hitEffectAnim;
       public float SelfDestructTime = 2.0f;
       public PlayerHealth PlayerHealth;

       void Start() {
             //NOTE: transform gets location, but we need Vector2 for direction, so we can use MoveTowards.
             playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
             target = new Vector2(playerTrans.position.x, playerTrans.position.y);

             StartCoroutine(selfDestruct());
       }

       void Update () {
              transform.position = Vector2.MoveTowards (transform.position, target, speed * Time.deltaTime);
       }

       //if the bullet hits a collider, play the explosion animation, then destroy the effect and the bullet
       void OnTriggerEnter2D(Collider2D collision){
              if (collision.gameObject.tag == "Player") {
                     PlayerHealth.TakeDamage(damage);
              }
              if (collision.gameObject.tag != "enemyShooter") {
                     Debug.Log("Should self-destruct");
                     //GameObject animEffect = Instantiate (hitEffectAnim, transform.position, Quaternion.identity);
                     //Destroy (animEffect, 0.5f);
                     gameObject.SetActive(false);
                     //Destroy (gameObject);
              }
       }

       IEnumerator selfDestruct(){
              yield return new WaitForSeconds(SelfDestructTime);
              gameObject.SetActive(false);
              //Destroy (gameObject);
       }
}
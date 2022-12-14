using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

       public int damage = 100;
       public float speed = 10f;
       private Transform playerTrans;
       private Vector2 target;
       public GameObject hitEffectAnim;
       public float SelfDestructTime = 2.0f;
       private PlayerHealth PlayerHealth;
       
    

       void Start() {
             //NOTE: transform gets location, but we need Vector2 for direction, so we can use MoveTowards.
             playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
             PlayerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
             target = new Vector2(playerTrans.position.x, playerTrans.position.y);

             StartCoroutine(selfDestruct());

              //new code for trajectory:
              Vector2 startPos = transform.position;
              float distance = Vector2.Distance(startPos, target);
              distance = distance * (10);
              Vector2 difference = target - startPos;
              difference = difference.normalized * distance;
              target = (startPos + difference);
       }


       void Update () {
              
        transform.position = Vector2.MoveTowards (transform.position, target, speed * Time.deltaTime);
       }

       //if the bullet hits a collider, play the explosion animation, then destroy the effect and the bullet
       void OnTriggerEnter2D(Collider2D collision){
              Debug.Log("HIT: " + collision.gameObject.tag);
              if (collision.gameObject.tag == "Player") {
                     //Debug.Log("HIT PLAYER");
                     PlayerHealth.TakeDamage(damage);
            GameObject animEffect = Instantiate(hitEffectAnim, transform.position, Quaternion.identity);
            Destroy(animEffect, 0.5f);
            gameObject.SetActive(false);
                  
        } else if (collision.gameObject.tag != "enemyShooter") {
                     GameObject animEffect = Instantiate (hitEffectAnim, transform.position, Quaternion.identity);
                     Destroy (animEffect, 0.5f);
                     Debug.Log("HIT SOMETHING OTHER THAN PLAYER");
                     gameObject.SetActive(false);
                   
        }
       }

       IEnumerator selfDestruct(){
              yield return new WaitForSeconds(SelfDestructTime);
        //Debug.Log("SELF DESTRUCTING");
        GameObject animEffect = Instantiate(hitEffectAnim, transform.position, Quaternion.identity);
        Destroy(animEffect, 0.5f);
        gameObject.SetActive(false);
          
    }

        
}
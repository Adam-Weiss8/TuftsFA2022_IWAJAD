using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour{

      public Animator anim;
      public Transform attackPt;
      public float attackRange = 0.5f;
      public float attackRate = 2f;
      private float nextAttackTime = 0f;
      public int attackDamage = 40;
      public LayerMask enemyLayers;
      private AudioSource playerAudio;
      public AudioClip hitNoise;
 

      void Start(){
           anim = gameObject.GetComponentInChildren<Animator>();
           playerAudio = GetComponent<AudioSource>();
    }

      void Update(){
           if (Time.time >= nextAttackTime){
                  //if (Input.GetKeyDown(KeyCode.Space))
                 if (Input.GetAxis("attack") > 0){
                        playerAudio.PlayOneShot(hitNoise);
                        Attack();
                        nextAttackTime = Time.time + 1f / attackRate;
                  }
            }
      }

      void Attack(){
            anim.SetTrigger ("attack");
            Debug.Log("hit animation");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPt.position, attackRange, enemyLayers);
           
            foreach(Collider2D enemy in hitEnemies){
                  Debug.Log("We hit " + enemy.name);
                  enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
                  enemy.GetComponent<EnemyPatrolNew>().Knockback();
            }
      }

      //NOTE: to help see the attack sphere in editor:
      void OnDrawGizmosSelected(){
           if (attackPt == null) {return;}
            Gizmos.DrawWireSphere(attackPt.position, attackRange);
      }
}
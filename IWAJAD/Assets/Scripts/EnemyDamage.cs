using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage;
    public PlayerHealth PlayerHealth;
    // Start is called before the first frame update
    
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Player") {
            PlayerHealth.TakeDamage(damage);
        }
    }
}

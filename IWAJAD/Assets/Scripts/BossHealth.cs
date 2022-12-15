using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
	public int health;
	public Bar HealthBar;

    void Start()
    {
        Debug.Log("INITIALIZED MAX HEALTH");
        HealthBar.SetMaxHealth(health);
    }

    
    void Update()
    {
		if (health <= 0) {
			Destroy(gameObject);
		}
    }
	
	public void TakeDamage(int damage){
        Debug.Log("BOSS TAKING DAMAGE");
		health -= damage;
        HealthBar.SetHealth(health);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
	public int health;
	public Bar HealthBar;
	public PlayerHealth PlayerHealth;
	private int originalHealth;
	private string sceneName;

    void Start()
    {
		originalHealth = health;
		HealthBar.SetMaxHealth(health);
		Scene currentScene = SceneManager.GetActiveScene ();
		sceneName = currentScene.name;
    }

    
    void Update()
    {
		if (sceneName == "BossBattle") {
			Debug.Log("PH from enemy: " + PlayerHealth.health);
			if(PlayerHealth.health <= 0) {
				health = originalHealth;
				HealthBar.SetMaxHealth(health);
			}
		}
		if (health <= 0) {
			Destroy(gameObject);
		}
    }
	
	public void TakeDamage(int damage){
		Debug.Log("taking damage?");
		health -= damage;
		if (sceneName == "BossBattle") {
			HealthBar.SetHealth(health);
		}
	}
}


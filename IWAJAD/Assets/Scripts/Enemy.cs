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
	private Renderer rend;
	public AudioSource audioSource;

    void Start()
    {
		originalHealth = health;
		Scene currentScene = SceneManager.GetActiveScene ();
		sceneName = currentScene.name;
		if (sceneName == "BossBattle 1" || sceneName == "BossBattle 2") {
			Debug.Log("Sets max health");
			HealthBar.SetMaxHealth(health);
			audioSource = GetComponent<AudioSource>();
		}
		rend = GetComponentInChildren<Renderer> ();
    }

    
    void Update()
    {
		// if (sceneName == "BossBattle 1" || sceneName == "BossBattle 2") {
		// 	if(PlayerHealth.health <= 0) {
		// 		health = originalHealth;
		// 		HealthBar.SetMaxHealth(health);
		// 	}
		// }
		if (sceneName == "BossBattle 1" || sceneName == "BossBattle 2") {
			if (health == originalHealth - 40 || health == originalHealth - 200 || health == originalHealth - 400
				|| health == originalHealth - 600 || health == originalHealth - 800) {
				audioSource.Play();
			}
			if (sceneName == "BossBattle 1" && health <= 100) {
				StopCoroutine("HitEnemy");
        		StartCoroutine("HitEnemy");
				StopCoroutine("HitEnemy");
    			StartCoroutine("HitEnemy");
				StopCoroutine("HitEnemy");
        		StartCoroutine("HitEnemy");
				audioSource.Play();
				gameObject.SetActive(false);
			}
			if (sceneName == "BossBattle 2" && health <= 0) {
				audioSource.Play();
				audioSource.Play();
			}
		}
		if (health < originalHealth) {
			PlayerController player = GameObject.FindObjectOfType<PlayerController>();
			if (!player.killedEnemies.ContainsKey(gameObject)) {
				player.killedEnemies.Add(gameObject, 0);
			}
		}
		if (health <= 0) {
			gameObject.SetActive(false);
		}
		// if (health <= 0) {
		// 	// Add the enemy to the player's dictionary of killed enemies
        // 	PlayerController player = GameObject.FindObjectOfType<PlayerController>();
        // 	player.killedEnemies.Add(gameObject, 0);
		// 	gameObject.SetActive(false);
		// }
    }
	
	public void TakeDamage(int damage){
		Debug.Log("taking damage?");
		StopCoroutine("HitEnemy");
        StartCoroutine("HitEnemy");
		health -= damage;
		if (sceneName == "BossBattle 1" || sceneName == "BossBattle 2") {
			HealthBar.SetHealth(health);
		}
	}

	IEnumerator HitEnemy(){
              // color values are R, G, B, and alpha, each divided by 100
              rend.material.color = new Color(2.4f, 0.9f, 0.9f, 0.5f);
              // if (EnemyLives < 1){
              //        //gameControllerObj.AddScore (5);
              //        Debug.Log("HERE");
              //        Destroy(gameObject);
              // }
              yield return new WaitForSeconds(0.5f);
              rend.material.color = Color.white;
       }

	public void RevertColor() {
		rend.material.color = Color.white;
	}

	public void ResetHealth() {
		health = originalHealth;
		if (sceneName == "BossBattle 1" || sceneName == "BossBattle 2") {
			HealthBar.SetMaxHealth(health);
		}
	}
}


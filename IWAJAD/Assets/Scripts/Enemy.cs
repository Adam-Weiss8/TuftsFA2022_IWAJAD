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

    void Start()
    {
		originalHealth = health;
		Scene currentScene = SceneManager.GetActiveScene ();
		sceneName = currentScene.name;
		if (sceneName == "BossBattle 1") {
			HealthBar.SetMaxHealth(health);
		}
		rend = GetComponentInChildren<Renderer> ();
    }

    
    void Update()
    {
		if (sceneName == "BossBattle 1") {
			Debug.Log("PH from enemy: " + PlayerHealth.health);
			if(PlayerHealth.health <= 0) {
				health = originalHealth;
				HealthBar.SetMaxHealth(health);
			}
		}
		if (sceneName == "BossBattle 1") {
			if (health <= 100) {
				StopCoroutine("HitEnemy");
        		StartCoroutine("HitEnemy");
				StopCoroutine("HitEnemy");
    			StartCoroutine("HitEnemy");
				StopCoroutine("HitEnemy");
        		StartCoroutine("HitEnemy");
				Destroy(gameObject);
			}
		}
		if (health <= 0) {
			Destroy(gameObject);
		}
    }
	
	public void TakeDamage(int damage){
		Debug.Log("taking damage?");
		StopCoroutine("HitEnemy");
        StartCoroutine("HitEnemy");
		health -= damage;
		if (sceneName == "BossBattle 1") {
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
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int health = 5;
    public int Respawn;
    public PlayerRespawn PlayerRespawn;
    private string sceneName;
    public Bar HealthBar;
    private Renderer rend;
    private PlayerController playerController;
    public AudioSource playerDeath;

    void Start()
    {
        health = maxHealth;
        Debug.Log("Health was initialized to: " + health);
        Scene currentScene = SceneManager.GetActiveScene ();
		sceneName = currentScene.name;
        HealthBar.SetMaxHealth(health);
        rend = GetComponentInChildren<Renderer> ();
        playerController = GameObject.FindObjectOfType<PlayerController>();
        playerDeath = GetComponent<AudioSource>();
    }

    void Update() {
        Debug.Log("Health in PH is: " + health);
    }

    public void TakeDamage(int damage) {
        Debug.Log("I have taken damage");
        StopCoroutine("HitEnemy");
        StartCoroutine("HitEnemy");
        health -= damage;
        HealthBar.SetHealth(health);
        if (health <= 0) {
            Debug.Log("I should die");
            playerDeath.Play();
            playerController.OnDeath();
            PlayerRespawn.respawn();
            HealthBar.SetMaxHealth(health);
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

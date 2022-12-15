using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 1;
    public int health;
    public int Respawn;
    public PlayerRespawn PlayerRespawn;

    void Start()
    {
        health = maxHealth;
        Debug.Log("Health was initialized to: " + health);
    }

    void Update() {
        Debug.Log("Health in PH is: " + health);
    }

    public void TakeDamage(int damage) {
        Debug.Log("I have taken damage");
        health -= damage;
        if (health <= 0) {
            Debug.Log("I should die");
            PlayerRespawn.respawn();
            health = 1;
        }
    }
}

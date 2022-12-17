using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // A dictionary to store the enemies that have been killed by the player
    public Dictionary<GameObject, int> killedEnemies;

    void Start()
    {
        // Initialize the dictionary
        killedEnemies = new Dictionary<GameObject, int>();
    }

    public void OnDeath()
    {
        // Iterate through the dictionary and reset the health of each enemy
        foreach (KeyValuePair<GameObject, int> enemy in killedEnemies)
        {
            enemy.Key.GetComponent<Enemy>().ResetHealth();
            enemy.Key.gameObject.SetActive(true);
            enemy.Key.GetComponent<Enemy>().RevertColor();
        }

        // Clear the dictionary
        killedEnemies.Clear();
    }
}


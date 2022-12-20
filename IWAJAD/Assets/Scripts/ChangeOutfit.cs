using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeOutfit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Level 1R" || scene.name == "Level 2R" || scene.name == "Level 3R" || scene.name == "Level 4R" || scene.name == "Level 5R")
        {
            //change character sprite
            GameObject player = GameObject.Find("Player");
            Animator anim = player.GetComponent<Animator>();
            anim.SetTrigger("awake");
        }
    }

  
}

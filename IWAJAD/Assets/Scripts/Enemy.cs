using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public int health;
	public float speed;
    private float dazedTime;
	public float startDazedTime;
   
    void Start()
    {
        
    }

    
    void Update()
    {
		if(dazedTime <= 0) {
			speed = 5;
		} else {
			speed = 0;
			dazedTime -= Time.deltaTime;
		}	
		
		if (health <= 0) {
			Destroy(gameObject);
		}	
    }
	
	public void TakeDamage(int damage){
		dazedTime = startDazedTime;
		health -= damage;
	}	
}

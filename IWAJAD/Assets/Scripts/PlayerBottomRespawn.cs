using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerBottomRespawn : MonoBehaviour {

       public Transform playerPos;
       public Transform pSpawnFall;

       void Start() {
              playerPos = GameObject.FindWithTag("Player").GetComponent<Transform>();
       }

       void Update() {
              if (playerPos != null){
                     //Capture Checkpoint changes:
                     pSpawnFall = playerPos.gameObject.GetComponent<PlayerRespawn>().pSpawn;

                     if (transform.position.y >= playerPos.position.y){
                            //instantiate a particle effect
                            Debug.Log("I am going back to the start");
                            Vector3 pSpn2 = new Vector3(pSpawnFall.position.x, pSpawnFall.position.y, playerPos.position.z);
                            playerPos.position = pSpn2;
                     }
              }
       }
}

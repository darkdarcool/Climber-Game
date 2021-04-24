using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    public Transform player;
    public Transform respawnPoint;
    private void OnTriggerEnter(Collider other) // On touch of the wall
    {
			/*
			Just to figure out who hit the death wall!
			Debug.Log(other.name);
			*/
			if (other.name == "Player") {
				// Event where the player hits a death wall
				player.transform.position = respawnPoint.transform.position;
			}
			else {
				// This is the even where the bullet hits a death wall
			}
			
        
    }
}

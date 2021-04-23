using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    private void OnTriggerEnter(Collider other)
    {
			Debug.Log(other);
			if (other == player.transform) {
				Debug.Log("Player Hit Me!");
			}
			Debug.Log("Hello! Respawning!");
        player.transform.position = respawnPoint.transform.position;
    }
}

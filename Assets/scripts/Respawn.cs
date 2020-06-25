using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    public GameObject Player;
    public GameObject RespawnTracker;
    public int respawnTimer = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        respawnTimer++;
        Debug.Log(respawnTimer);
        if (respawnTimer == 200)
        {
            Player.SetActive(true); // pacman respawns
            respawnTimer = 0;
            RespawnTracker.SetActive(false);  // turn off respawn tracker
        }

    }
}

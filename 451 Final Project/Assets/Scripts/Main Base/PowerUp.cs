using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

	/*
	Class for future power up.
	Holds an integer which will randomly determine which powerup
	the player will get on collection
	
	On touching shield or player bullet, grabs power up from the core
	object and runs a specific function based on mode.
	 */
	int mode;
	void Start () {
		mode = Random.Range(0, PlayerPowerUps.maxPowers);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("PlayerBullet") || other.CompareTag("Shield"))
		{
			PlayerPowerUps temp = GameObject.Find("Core").GetComponent<PlayerPowerUps>();
			temp.powers[mode]++;
			//Etc for rest of available power ups

			Destroy(gameObject);
		}
	}
}

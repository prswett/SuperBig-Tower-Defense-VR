using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushEnemy : MonoBehaviour {

	/*
	Enemy that moves toward the core
	Change speed to modify how fast it moves
	change damage to modify how much damage it does

	 */
	public GameObject core;
	int damage;
	float speed;
	EnemyStatistics mystats;

	void Awake()
	{
		core = GameObject.Find("Core");
		mystats = GetComponent<EnemyStatistics>();

	}

	void Start () {
		speed = mystats.speed;
		damage = mystats.damage;
	}
	
	float step;
	void Update () {
		step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, core.transform.position, step);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Core"))
		{
			Core script = other.GetComponent<Core>();
			script.takeDamage(damage);
			Destroy(gameObject);
		}
	}
}

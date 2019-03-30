using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemy : MonoBehaviour {

	/*
	 * Enemy moves to certain distance within core and shoots projectiles at core
	 */

	public GameObject core;
	public GameObject shootEnemyProjectile;
	int damage;
	float speed;
	EnemyStatistics mystats;
	float spawnTime;
	float shootRate;
	public float distance;


	void Awake()
	{
		core = GameObject.Find("Core");
		mystats = GetComponent<EnemyStatistics>();

	}

	void Start () {
		if (distance <= 0f) {
			distance = 3f;
		}
		shootRate = 5.0f;
		spawnTime = Time.time;
		speed = mystats.speed;
		damage = mystats.damage;
	}
	
	float step;
	void Update () {
		step = speed * Time.deltaTime;
		// move to 5 distance away from core
		Vector3 initial = transform.localPosition;
		transform.forward = transform.position - core.transform.position;
		transform.position += transform.right * 0.005f;
		if ((initial - core.transform.localPosition).magnitude > distance + 0.2) {
			transform.position = Vector3.MoveTowards (transform.position, Vector3.MoveTowards (transform.position, core.transform.position, step).normalized * distance, step);
			spawnTime = Time.time;
		} else {
			if ((Time.time - spawnTime) > shootRate) {
				shootEnemyBullet ();
				spawnTime = Time.time;
			}
		}
	}

	void shootEnemyBullet(){
		Instantiate (shootEnemyProjectile, transform.position, Quaternion.identity);
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

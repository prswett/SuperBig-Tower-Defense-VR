using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
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
	
	// Update is called once per frame
	float step;
	void Update () {
		step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, core.transform.position, step);
		transform.up = -(transform.position - core.transform.position);
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

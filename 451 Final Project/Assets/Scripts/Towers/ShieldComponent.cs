using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldComponent : MonoBehaviour {

	/**
	Shield component
	If the shield touches an enemy and its been more than cooldown time,
	the enemy will be destroyed

	If the shield touches bullets, the bullets will be destroyed
	 */
	public NodePrimitive node;

	public float shieldEnemyCD;
	TowerPowerups powerups;

	void Awake()
	{
		powerups = GetComponent<TowerPowerups>();
	}
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = node.matrix.GetColumn(3);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy"))
		{
			if (Time.time - shieldEnemyCD >= GlobalStats.shieldEnemyBlockRate * powerups.shieldEnemyBlockRate)
			{
				Destroy(other.gameObject);
				shieldEnemyCD = Time.time;
			}
		}

		if (other.CompareTag("EnemyBullet"))
		{
			Destroy(other.gameObject);
		}
	}
}

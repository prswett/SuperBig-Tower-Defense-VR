using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBulletHead : MonoBehaviour {

	public int damage;
	void Start () {

		if (damage == 0)
		{
			damage = (int)(GlobalStats.bulletDamage * 2 * transform.GetComponentInParent<BulletPowerUp>().bulletDamage);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy"))
		{
			EnemyStatistics temp = other.GetComponent<EnemyStatistics>();
			temp.takeDamage(damage);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBulletHead : MonoBehaviour {

	public int damage;
	int count = 0;

	void Start () {
		if (damage == 0)
		{
			damage = (int)(GlobalStats.bulletDamage * 3 * transform.GetComponentInParent<BulletPowerUp>().bulletDamage);;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy"))
		{
			count++;
			EnemyStatistics temp = other.GetComponent<EnemyStatistics>();
			temp.takeDamage(damage);

			if (count > GlobalStats.heavybulletHitCount)
			{
				Bullet parent = GetComponentInParent<Bullet>();
				parent.destroy();
			}
		}
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHead : MonoBehaviour {

	/*
	Collider component of bullet.
	Comes with damage integer which represents how much damage it will do

	Upon touching an enemy the bullet will deal damage and dissapear
	 */
	public int damage;
	// Use this for initialization
	void Start () {
		if (damage == 0)
		{
			damage = (int)(GlobalStats.bulletDamage * transform.GetComponentInParent<BulletPowerUp>().bulletDamage);;
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
			Bullet parent = GetComponentInParent<Bullet>();
			parent.destroy();
		}
	}
}

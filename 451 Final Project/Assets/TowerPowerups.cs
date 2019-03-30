using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPowerups : MonoBehaviour {

	public float bulletDamage;
    public float bulletSpeed;
    public float attackRate;
    public float shieldEnemyBlockRate;
    public float heavybulletHitCount;

	void Start () {
		bulletDamage = 1;
		bulletSpeed = 1;
		attackRate = 1;
		shieldEnemyBlockRate = 1;
		heavybulletHitCount = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void attackRateBoost()
	{
		attackRate /= 2f;
		Invoke("attackRateReset", 10f);
	}

	public void attackRateReset()
	{
		attackRate *= 2f;
	}

	public void bulletDamageBoost()
	{
		bulletDamage *= 1.5f;
		Invoke("bulletDamageReset", 5f);
	}

	public void bulletDamageReset()
	{
		bulletDamage /= 1.5f;
	}

	public void shieldBlockRateBoost()
	{
		shieldEnemyBlockRate /= 2f;
		Invoke("shieldBlockRateReset", 5f);
	}

	public void shieldBlockRateReset()
	{
		shieldEnemyBlockRate *= 2f;
	}
}

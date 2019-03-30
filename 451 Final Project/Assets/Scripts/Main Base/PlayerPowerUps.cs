using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerPowerUps : MonoBehaviour {

	/*
	Class that will hold player collected power ups
	 */


	int layer;
	
	// Update is called once per frame
	void Update () {
		
	}

	public void increaseFireRate()
	{
		if (GlobalStats.attackRate > .1f)
		{
			GlobalStats.attackRate -= .1f;
		}
	}

	public void increaseShieldRate()
	{
		if (GlobalStats.shieldEnemyBlockRate > .1f)
		{
			GlobalStats.shieldEnemyBlockRate -= .1f;
		}
	}

	public void increaseDamage()
	{
		GlobalStats.bulletDamage++;
	}

	RaycastHit rayHit;
	public void towerAttackRate(Transform controller)
	{
		
		if (Physics.Raycast(controller.position, controller.transform.forward, out rayHit, Mathf.Infinity, layer))
            {
                if (rayHit.transform.CompareTag("TowerGunPower"))
                {
                   TowerPowerups temp = rayHit.transform.GetComponent<PowerUpLink>().power;
				   temp.attackRateBoost();
				   powers[3]--;
                }
            }
	}

	public void towerDamage(Transform controller)
	{
		if (Physics.Raycast(controller.position, controller.transform.forward, out rayHit, Mathf.Infinity, layer))
            {
                if (rayHit.transform.CompareTag("TowerGunPower"))
                {
                   TowerPowerups temp = rayHit.transform.GetComponent<PowerUpLink>().power;
				   temp.bulletDamageBoost();
				   powers[4]--;
                }
            }
	}

	public void towerShieldRate(Transform controller)
	{
		if (Physics.Raycast(controller.position, controller.transform.forward, out rayHit, Mathf.Infinity, layer))
            {
                if (rayHit.transform.CompareTag("TowerDefensePower"))
                {
                   TowerPowerups temp = rayHit.transform.GetComponent<PowerUpLink>().power;
				   temp.shieldBlockRateBoost();
				   powers[5]--;
                }
            }
	}
}

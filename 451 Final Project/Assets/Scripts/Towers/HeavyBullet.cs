using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBullet : MonoBehaviour {

	public float speed;

	void Start () {
		if (speed == 0)
		{
			speed = GlobalStats.bulletSpeed;
			speed *= 2.5f;
		}
		Destroy(gameObject, 3f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.up * speed * GetComponentInParent<BulletPowerUp>().bulletSpeed;
	}

	public void destroy()
	{
		Destroy(gameObject);
	}
}

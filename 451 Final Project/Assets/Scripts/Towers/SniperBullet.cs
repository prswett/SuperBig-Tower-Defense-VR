using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBullet : MonoBehaviour {

	public float speed;
	int count = 0;
	void increaseSpeed()
    {
        speed *= 1.6f;
        count++;
        if (count < 5)
        {
            Invoke("increaseSpeed", 0.3f);
        }
    }
	void Start () {
		if (speed == 0)
        {
            speed = GlobalStats.bulletSpeed * GetComponentInParent<BulletPowerUp>().bulletSpeed;
        }
        Invoke("increaseSpeed", 0.5f);
        Destroy(gameObject, 3f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.up * speed;
	}
}

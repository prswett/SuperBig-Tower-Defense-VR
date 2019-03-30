using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    /*
	Component of a bullet that moves it

	Moves a bullet via its up vector by a speed
	change speed to change how fast bullet moves

    if a bullet has found a target, homes the bullet on that target
	 */
    public float speed;
    int count = 0;

    void Awake()
    {

    }

    void increaseSpeed()
    {
        speed *= 1.5f;
        count++;
        if (count < 5)
        {
            Invoke("increaseSpeed", 0.5f);
        }
    }

    void Start()
    {
        if (speed == 0)
        {
            speed = GlobalStats.bulletSpeed * GetComponentInParent<BulletPowerUp>().bulletSpeed;
        }
        Invoke("increaseSpeed", 0.5f);
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.position += transform.up * speed;
    }

    public void destroy()
    {
        Destroy(gameObject);
    }
}

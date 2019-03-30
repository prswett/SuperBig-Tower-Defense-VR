using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatistics : MonoBehaviour
{

    /*
	Enemy Health class
	Records current health and max health (change max health to change default starting health)
	Provides takeDamage function which decreases health by an amount

	 */
    public int health;
    public int maxHealth;
    public int damage;
    public float speed;

    public GameObject powerup;
    public Transform core;
    public bool bullet = false;

    Renderer r;
	Material m;

    void Awake()
    {
		//We only grab from global stats if we have not set health yet
        if (maxHealth == 0)
        {
            maxHealth = EnemyStats.enemyHealth;
        }
        if (damage == 0)
        {
            damage = EnemyStats.enemyDamage;
        }
        if (speed == 0)
        {
            speed = EnemyStats.enemySpeed;
        }
        health = maxHealth;
        r = GetComponent<Renderer>();
        m = r.material;
        core = GameObject.Find("Core").transform;
        
    }

    void Start()
    {
        //m.color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            GameStats.score++;
            GameStats.money++;
            int temp = Random.Range(0, 10);
            if (temp < 1)
            {
                Instantiate(powerup, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
        if (!bullet)
        {
            transform.forward = -(transform.position - core.transform.position);
        }
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        /**if (((float) health / (float) maxHealth) <= .5f)
        {
            m.color = Color.magenta;
        }*/
    }
}

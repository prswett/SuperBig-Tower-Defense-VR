using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    /*
	Enemy spawner script

	Spawns enemies within a box of its current location
	spawnRate represents how often an enemy will spawn (in seconds)
	 */
    public GameObject enemyToSpawn;
    public EnemyStats enemyStats;
    public float spawnCD;
    public float spawnRate;

    public float spawnBoxX;
    public float spawnBoxY;
    public float spawnBoxZ;

    public bool active = false;
    public Transform core;
    void Start()
    {
        //Only change values if they have not been set yet
        if (spawnRate == 0)
        {
            spawnRate = EnemyStats.enemySpawnRate;
        }
        if (spawnBoxX == 0)
        {
            spawnBoxX = EnemyStats.enemySpawnX;
        }
        if (spawnBoxY == 0)
        {
            spawnBoxY = EnemyStats.enemySpawnY;
        }
        if (spawnBoxZ == 0)
        {
            spawnBoxZ = EnemyStats.enemySpawnZ;
        }
        transform.localScale = new Vector3(spawnBoxX * 2, spawnBoxY * 2, spawnBoxZ * 2);

        enemyStats = GameObject.Find("Core").GetComponent<EnemyStats>();
        core = GameObject.Find("Core").transform;
        //Change for different enemies
        
    }

    // Update is called once per frame
    void Update()
    {
        if (active && Time.timeScale != 0)
        {
            if (Time.time - spawnCD >= spawnRate || spawnCD == 0)
            {
				spawnRandomEnemy ();
            }
            transform.right = transform.position - core.position;
        }
    }

	public void spawnRandomEnemy(){
		// < 1 is rush
		// < 3 is hover
		// < 4 is shoot
		int a = Random.Range (0, 100);
		float x = Random.Range(spawnBoxX * -1, spawnBoxX);
		float y = Random.Range(spawnBoxY * -1, spawnBoxY);
		float z = Random.Range(spawnBoxZ * -1, spawnBoxZ);
		Vector3 spawn = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z + z);
		if (a < 25) {
			Instantiate (enemyStats.RushEnemy, spawn, Quaternion.identity);
			spawnCD = Time.time;
		} else if (a < 35) {
			Instantiate (enemyStats.HoverEnemy, spawn, Quaternion.identity);
			spawnCD = Time.time;
		} else if (a < 45) {
			Instantiate (enemyStats.HoverEnemyDF2, spawn, Quaternion.identity);
			spawnCD = Time.time;
		} else if (a < 55) {
			Instantiate (enemyStats.HoverEnemyDF3, spawn, Quaternion.identity);
			spawnCD = Time.time;
		} else if (a < 65) {
			Instantiate (enemyStats.ZigZagDF1, spawn, Quaternion.identity);
			spawnCD = Time.time;
		} else if (a < 75) {
			Instantiate (enemyStats.ZigZagDF2, spawn, Quaternion.identity);
			spawnCD = Time.time;
		} else if (a < 85) {
			Instantiate (enemyStats.ZigZagEnemy, spawn, Quaternion.identity);
			spawnCD = Time.time;
		} else if (a < 95) {
			Instantiate (enemyStats.ZigZagDF3, spawn, Quaternion.identity);
			spawnCD = Time.time;
		} else {
			Instantiate (enemyStats.ShootEnemy, spawn, Quaternion.identity);
			spawnCD = Time.time;
		}
	}

    public void updateStats()
    {
        spawnRate = EnemyStats.enemySpawnRate;
        spawnBoxX = EnemyStats.enemySpawnX;
        spawnBoxY = EnemyStats.enemySpawnY;
        spawnBoxZ = EnemyStats.enemySpawnZ;
        transform.localScale = new Vector3(spawnBoxX * 2, spawnBoxY * 2, spawnBoxZ * 2);
    }

    void spawn()
    {
        float x = Random.Range(spawnBoxX * -1, spawnBoxX);
        float y = Random.Range(spawnBoxY * -1, spawnBoxY);
        float z = Random.Range(spawnBoxZ * -1, spawnBoxZ);
        Vector3 spawn = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z + z);
        Instantiate(enemyToSpawn, spawn, Quaternion.identity);
        spawnCD = Time.time;
    }

    public void setActive()
    {
        active = true;
    }

    public void setUnActive()
    {
        active = false;
        updateStats();
    }
}

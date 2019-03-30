using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

	/*
	Class for holding all enemies
	 */
	public GameObject RushEnemy;
    public GameObject HoverEnemy;
    public GameObject HoverEnemyDF2;
    public GameObject HoverEnemyDF3;
	public GameObject ShootEnemy;
    public GameObject ZigZagEnemy;
    public GameObject ZigZagDF1;
    public GameObject ZigZagDF2;
    public GameObject ZigZagDF3;


    //Enemy Stats
    public static float enemySpeed;
	public static int enemyDamage;
	public static int enemyHealth;
	public static float enemySpawnRate;
	public static float enemySpawnX;
	public static float enemySpawnY;
	public static float enemySpawnZ;

	
	void Awake () {
		enemySpeed = .2f;
		enemyDamage = 1;
		enemyHealth = 1;
		enemySpawnRate = 7f;

		enemySpawnX = .5f;
		enemySpawnY = .5f;
		enemySpawnZ = .5f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

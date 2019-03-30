using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStats : MonoBehaviour
{

    /*
	Class that holds global variables for gameplay
	Used to reduce calculation costs and make
	easy access for stats
	 */
    public static int maxHealth;
    public static int bulletDamage;
    public static float bulletSpeed;
    public static float attackRate;
    public static float shieldEnemyBlockRate;
    public static float heavybulletHitCount;
	public static float aimLineLength;

    void Awake()
    {
		maxHealth = 100;

        bulletDamage = 1;
        bulletSpeed = .1f;
        attackRate = 1f;
        heavybulletHitCount = 5f;
        shieldEnemyBlockRate = 5f;
		aimLineLength = 5;
    }

    // Update is called once per frame
    void Update()
    {

    }

	public static int[] coreHealth;
	public static void updateCore()
	{
		Core[] cores = Object.FindObjectsOfType<Core>();
		coreHealth = new int[cores.Length];
		for (int i = 0; i < cores.Length; i++)
		{
			float healthPercent = cores[i].health / cores[i].maxHealth;
			coreHealth[i] = maxHealth;
			cores[i].maxHealth = maxHealth;
			cores[i].health = (int)(maxHealth * healthPercent);
		}
	}

	public static void restoreCoreHealth()
	{
		Core[] cores = Object.FindObjectsOfType<Core>();
		for (int i = 0; i < cores.Length; i++)
		{
			float healthPercent = cores[i].health / cores[i].maxHealth;
			cores[i].maxHealth = coreHealth[i];
			cores[i].health = (int)(coreHealth[i] * healthPercent);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStats : MonoBehaviour
{

    /**
    Class that managers the time, level, and score system for the game
     */
    public int levelTime;
    public float currentTime;
    public int level;
    public static int score;
    public static int money;
    GameObject[] enemySpawners;


    public Text levelText;
    public Text levelTimeText;
    public Text scoreText;
    public Text moneyText;
    public GameObject nextLevelText;

    void Start()
    {
        //How long each level is
        levelTime = 60;
        //Starting level and score
        level = 1;
        score = 0;
        money = 10000;
        //Activates enemy spawners for first level
        enemySpawners = GameObject.FindGameObjectsWithTag("EnemySpawner");
        deactivateSpawners();
        activateSpawners();
        currentTime = Time.time;
        levelText.text = "Level: " + level;
        
    }

    void activateSpawners()
    {
        //Grabs all spawners. Number of spawners activated is equal to the current level divided by 3 + 1
        //if level / 3 exceeds number of spawners, activate all
        
        int activateNumber = level / 5 + 1;
        if (activateNumber >= enemySpawners.Length)
        {
            for (int i = 0; i < enemySpawners.Length; i++)
            {
                EnemySpawner temp = enemySpawners[i].GetComponent<EnemySpawner>();
                temp.gameObject.SetActive(true);
                temp.setActive();
            }
        }
        //Randomly chooses spawners to activate
        else
        {
            for (int i = 0; i < activateNumber; i++)
            {
                int random = Random.Range(0, enemySpawners.Length);
                EnemySpawner temp = enemySpawners[random].GetComponent<EnemySpawner>();
                while (temp.active == true)
                {
                    random = Random.Range(0, enemySpawners.Length);
                    temp = enemySpawners[random].GetComponent<EnemySpawner>();
                }
                temp.gameObject.SetActive(true);
                temp.setActive();
            }
        }
    }

    //Deactivates all enemy spawners
    void deactivateSpawners()
    {
        for (int i = 0; i < enemySpawners.Length; i++)
        {
            EnemySpawner temp = enemySpawners[i].GetComponent<EnemySpawner>();
            temp.setUnActive();
            temp.gameObject.SetActive(false);
        }
    }

    //Updates score and time left text
    //If the time is out, run next level
    //Spacebar to next level is for testing purposes
    void Update()
    {
        scoreText.text = "Score: " + score;
        levelTimeText.text = "Time Left: " + (levelTime - (int)Mathf.CeilToInt(Time.time - currentTime));
        moneyText.text = "Money: " + money;
        if (Time.time - currentTime >= levelTime)
        {
            nextLevel();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            startNextLevel();
        }
    }

    //Removes all enemies and bullets from the world
    void nextLevel()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] enemyBullets = GameObject.FindGameObjectsWithTag("EnemyBullet");
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                Destroy(enemies[i]);
            }
        }
        for (int i = 0; i < enemyBullets.Length; i++)
        {
            if (enemyBullets[i] != null)
            {
                Destroy(enemyBullets[i]);
            }
        }
        //Updates score with base 10 plus 2 for every level completed
        score += 10 + (2 * level);
        money += 5 + (2 * level);
        level++;
        currentTime = Time.time;
        //Stops time in game and deactivates spawners
        Time.timeScale = 0;
        deactivateSpawners();
        //Show the text for starting next level
        nextLevelText.SetActive(true);
        levelText.text = "Level: " + level;

        if (level % 3 == 0)
        {
            increaseEnemyStats();
        }
        activateSpawners();
    }

    void increaseEnemyStats()
    {
        EnemyStats.enemySpeed *= 1.5f;
		EnemyStats.enemyDamage = (int)(EnemyStats.enemyDamage * 1.5f);
		EnemyStats.enemyHealth = (int)(EnemyStats.enemyHealth * 1.5f);
        if (EnemyStats.enemySpawnRate > .1f)
        {
            EnemyStats.enemySpawnRate -= .1f;
        }
    }

    //If timescale is 0, sets time to 1, activates spawners and removes text
    public void startNextLevel()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            nextLevelText.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverEnemyDF2 : MonoBehaviour {

    //enemy that moves towards the core
    //will continue to bomb the player while it moves towards the core

    //Diffculty 2


    GameObject core;
    EnemyStatistics mystats;
    public GameObject shootEnemyProjectile;

    public int damage;
    public float speed;
    public float bombCD;
    public bool bombReady;
    public float hoverDistance;

    void Awake()
    {
        core = GameObject.Find("Core");
        mystats = GetComponent<EnemyStatistics>();
    }

    void Start()
    {
        speed = mystats.speed * .8f;
        damage = mystats.damage * 2;
        bombCD = 4f;
        bombReady = true;
        hoverDistance = 1f;
    }

    float step;
    void Update()
    {
        step = speed * Time.deltaTime;
        float dist = Vector3.Distance(core.transform.position, transform.position);
        //if the distance from the core to enemy is > then hover distance then keep moving closer
        transform.position = Vector3.MoveTowards(transform.position, core.transform.position, step);
        
       //checks if bombcd is reset
       if (bombReady == true)
       {
            //if it is drop bomb
            bomb();
       }
        


    }

    //just keeping this here cuz why not incase some random bug causes it to kamikaze
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Core"))
        {
            Core script = other.GetComponent<Core>();
            script.takeDamage(damage);
            Destroy(gameObject);
        }
    }

    void bomb()
    {
        Instantiate(shootEnemyProjectile, transform.position, Quaternion.identity);
        //put bomb on cd
        bombReady = false;
        //reset the cd in bombCD time
        Invoke("resetBombCD", bombCD);
    }

    void resetBombCD()
    {
        bombReady = true;
    }
}

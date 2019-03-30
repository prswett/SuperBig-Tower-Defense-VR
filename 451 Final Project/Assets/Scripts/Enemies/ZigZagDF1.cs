using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagDF1 : MonoBehaviour {


    //enemy that moves towards the core while zigzagging
    //once it reaches a certain range it will stop and start bombing the player core


    GameObject core;
    EnemyStatistics mystats;
    public GameObject shootEnemyProjectile;

    public int damage;
    public float speed;
    public float bombCD;
    public bool bombReady;
    public float hoverDistance;
    float timer;
    int difficulty;//higher difficulty makes it slower
    int zig;//higher zig makes it zigzag more
    Vector3 zigzag;

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
        difficulty = 4;
        zig = 3;
    }

    float step;
    void Update()
    {

        step = speed * Time.deltaTime;
        float dist = Vector3.Distance(core.transform.position, transform.position);
        //if the distance from the core to enemy is > then hover distance then keep moving closer
        if (dist > hoverDistance)
        {
            timer += Time.deltaTime;
            if (timer < 0.5)
            {
                zigzag = zig * transform.right;
            }
            if (timer >= 0.5 && timer < 1)
            {
                zigzag = -zig * transform.right;
            }
            if (timer > 1)
            {
                timer = 0;
            }
            transform.position += (-(Vector3.MoveTowards(transform.position, core.transform.position, step) + zigzag) * Time.deltaTime) / difficulty;
        }
        //if the distance is within hover distance stay there and drop bombs on a CD
        else
        {
            //checks if bombcd is reset
            if (bombReady == true)
            {
                //if it is drop bomb
                bomb();
            }
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
        Debug.Log("Dopped bomb");
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

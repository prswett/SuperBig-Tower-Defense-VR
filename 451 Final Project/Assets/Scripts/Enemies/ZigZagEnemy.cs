using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagEnemy : MonoBehaviour {

    /* rush enemy but zigzags until it hits the core */

    public GameObject core;
    int damage;
    float speed;
    float delta;
    float timer;
    int difficulty; //higher difficulty makes it slower
    int zig; //higher zig makes it zigzag more
    Vector3 zigzag;
    EnemyStatistics mystats;

    void Awake()
    {
        core = GameObject.Find("Core");
        mystats = GetComponent<EnemyStatistics>();

    }

    void Start()
    {
        speed = mystats.speed;
        damage = mystats.damage;
        delta = 1.5f;
        difficulty = 4;
        zig = 3;
    }

    float step;
    void Update()
    {
        speed = 0.1f;
        step = speed * Time.deltaTime;

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
        transform.position += (-(Vector3.MoveTowards(transform.position, core.transform.position, step) + zigzag) * Time.deltaTime)/difficulty;
  

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Core"))
        {
            Core script = other.GetComponent<Core>();
            script.takeDamage(damage);
            Destroy(gameObject);
        }
    }
}

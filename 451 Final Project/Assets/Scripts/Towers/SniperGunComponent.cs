﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperGunComponent : MonoBehaviour
{

    public GameObject bullet;
    public float attackRate;
    public float attackCD;
    public Vector3 spawn;

    public NodePrimitive node;
    public LineRenderer line;
    TowerPowerups powerups;
    BulletPowerUp temp;
    public AutoAim aim;

    void Awake()
    {
        node = GetComponent<NodePrimitive>();
        powerups = GetComponent<TowerPowerups>();
        temp = bullet.GetComponent<BulletPowerUp>();
    }

    void updateLineRenderer()
    {
        Vector3 temp = node.matrix.GetColumn(3);
        line.SetPosition(0, temp);
        line.SetPosition(1, temp + node.transform.up * GlobalStats.aimLineLength);
    }
    void Start()
    {
        if (attackRate == 0)
        {
            attackRate = 2f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - attackCD >= GlobalStats.attackRate * attackRate * powerups.attackRate)
        {
            shootBullet();
        }
        updateLineRenderer();
    }

    void shootBullet()
    {
        spawn = node.matrix.GetColumn(3);
        attackCD = Time.time;
        temp.bulletDamage = powerups.bulletDamage;
        temp.bulletSpeed = powerups.bulletSpeed;
        if (aim.enemy != null)
        {
            Transform nBullet= Instantiate(bullet, spawn, Quaternion.identity).transform;
            nBullet.up = aim.enemy.position - nBullet.position;
        }
        else
        {
            Instantiate(bullet, spawn, Quaternion.LookRotation(node.matrix.GetColumn(2), node.matrix.GetColumn(1)));
        } 
    }
}

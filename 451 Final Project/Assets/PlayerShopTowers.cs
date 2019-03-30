using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShopTowers : MonoBehaviour {

	public static int availableTowers = 4;
    public int selected = 0;

    public TheWorld world;

    public GameObject gunTower;
    public GameObject shieldTower;
    public GameObject heavyGunTower;
    public GameObject sniperGunTower;

    public int gunTowerCost;
	public int shieldTowerCost;
	public int heavyGunTowerCost;
	public int sniperGunTowerCost;

    void Start()
    {
        gunTowerCost = 20;
        shieldTowerCost = 40;
        heavyGunTowerCost = 35;
        sniperGunTowerCost = 35;
    }

    public void selectNext()
    {
        selected++;
        if (selected >= availableTowers)
        {
            selected = 0;
        }
    }

    public void selectPrev()
    {
        selected--;
        if (selected < 0)
        {
            selected = availableTowers - 1;
        }
    }


    void spawnTower(GameObject input)
    {
        Vector3 temp = rayHit.point;
        Transform o = Instantiate(input, new Vector3(), Quaternion.identity).transform;
        SceneNode worldNode = o.GetComponent<SceneNode>();
        worldNode.NodeOrigin = temp;
        world.addSceneNode(worldNode);
    }

    RaycastHit rayHit;
    public void placeTower(Transform controller, int slayer)
    {
        if (Physics.Raycast(controller.position, controller.transform.forward, out rayHit, Mathf.Infinity, slayer))
        {
            if (rayHit.transform.CompareTag("StrategyBoard"))
            {
                switch (selected)
                {
                    
                    case 0:
                        if (GameStats.money >= gunTowerCost)
                        {
                            spawnTower(gunTower);
                            GameStats.money -= gunTowerCost;
                        }
                        break;
                    case 1:
                        if (GameStats.money >= shieldTowerCost)
                        {
                            spawnTower(shieldTower);
                            GameStats.money -= shieldTowerCost;
                        }
                        break;
                    case 2:
                        if (GameStats.money >= heavyGunTowerCost)
                        {
                            spawnTower(heavyGunTower);
                            GameStats.money -= heavyGunTowerCost;
                        }
                        break;
                    case 3:
                        if (GameStats.money >= sniperGunTowerCost)
                        {
                            spawnTower(sniperGunTower);
                            GameStats.money -= sniperGunTowerCost;
                        }
                        break;
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerPowerUps : MonoBehaviour
{

    public int[] powers;

    public int selected = 0;
    public static int maxPowers = 6;



    //Costs
    int fireRateCost = 10;
    int increaseDamageCost = 20;
    int shieldRateCost = 20;

    void Start()
    {
        powers = new int[maxPowers];
        for (int i = 0; i < maxPowers; i++)
        {
            powers[i] = 5;
        }
        layer = LayerMask.GetMask("TowerPowerUp");
    }

    public void selectNext()
    {
        selected++;
        if (selected >= maxPowers)
        {
            selected = 0;
        }
    }

    public void selectPrev()
    {
        selected--;
        if (selected < 0)
        {
            selected = maxPowers - 1;
        }
    }

    public void activatePower(Transform controller)
    {
        switch (selected)
        {
            case 0:
                if (powers[0] > 0)
                {
                    increaseFireRate();
                    powers[0]--;
                }
                else if (GameStats.money >= fireRateCost)
                {
                    increaseFireRate();
                    GameStats.money -= fireRateCost;
                }
                break;
            case 1:
                if (powers[1] > 0)
                {
                    increaseDamage();
                    powers[1]--;
                }
                else if (GameStats.money >= increaseDamageCost)
                {
                    increaseDamage();
                    GameStats.money -= increaseDamageCost;
                }
                break;
            case 2:
                if (powers[2] > 0)
                {
                    increaseShieldRate();
                    powers[2]--;
                }
                else if (GameStats.money >= shieldRateCost)
                {
                    increaseShieldRate();
                    GameStats.money -= shieldRateCost;
                }
                break;
            case 3:
                if (powers[3] > 0)
                {
                    towerAttackRate(controller);
                }
            break;
            case 4:
                if (powers[4] > 0)
                {
                    towerDamage(controller);
                }
            break;
            case 5:
                if (powers[5] > 0)
                {
                    towerShieldRate(controller);
                }
            break;
        }
    }

}

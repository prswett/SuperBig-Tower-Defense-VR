using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class Core : MonoBehaviour {

	/*
	Core (the center of the game)

	Comes with health and maxhealth (change maxhealth to increase starting health)
	Provides takeDamage function which is used by enemies to deal damage to the core

	 */
	public int health;
	public int maxHealth;
	public Image healthBar;
	public Text healthText;
	public GameObject restartUI;

	// Use this for initialization
	void Start () {
		maxHealth = GlobalStats.maxHealth;
		health = maxHealth;

        Renderer r = GetComponent<Renderer>();
        Material m = r.material;
        Color c = Color.white;
        c.a = .1f;
        m.color = c;

	}
	
	// Update is called once per frame
	void Update () {
		healthBar.fillAmount = (float)health / (float)maxHealth;
		healthText.text = health + " / " + maxHealth;
	}

	public void takeDamage(int damage)
	{
		if (health - damage < 0)
		{
			health = 0;
			restartUI.SetActive(true);
		}
		else
		{
			health -= damage;
		}
	}
}

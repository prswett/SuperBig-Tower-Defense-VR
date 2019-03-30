using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerUI : MonoBehaviour {

	public Image[][] images;
	public string[][] text;
	public Text textLine;

    PlayerPowerUps power;

    private void Awake()
    {
        power = FindObjectOfType<PlayerPowerUps>();
    }
    // Use this for initialization
    void Start () {
		images = new Image[5][];
        images[0] = new Image[1];
		images[1] = new Image[PlayerPowerUps.maxPowers];
		images[2] = new Image[PlayerShopTowers.availableTowers];
		images[3] = new Image[2];

		text = new string[5][];
        text[0] = new string[1];
		text[1] = new string[PlayerPowerUps.maxPowers];
		text[2] = new string[PlayerShopTowers.availableTowers];
		text[3] = new string[2];
        text[4] = new string[1];

        text[0][0] = "TRS Mode";

        text[2][0] = "Buy Gun Tower (20)";
		text[2][1] = "Buy Shield Tower (40)";
		text[2][2] = "Buy Heavy Tower (35)";
		text[2][3] = "Buy Sniper Tower (35)";

		text[3][0] = "VR Camera";
		text[3][1] = "World Camera";

        text[4][0] = "Translating Camera (up and down)";
	}
	
	// Update is called once per frame
	void Update () {
        text[1][0] = "Increase fire rate (all towers) (10) (" + power.powers[0] + " owned)";
        text[1][1] = "Increase damage (all towers) (20) (" + power.powers[1] + " owned)";
        text[1][2] = "Increase shield rate (all towers) (20) (" + power.powers[2] + " owned)";
        text[1][3] = "Increase tower attack rate (" + power.powers[3] + " owned)";
        text[1][4] = "Increase tower damage (" + power.powers[4] + " owned)";
        text[1][5] = "Increase tower shield rate (" + power.powers[5] + " owned)";
    }

	public void setText(int x, int y)
	{
		textLine.text = text[x][y];
	}
}

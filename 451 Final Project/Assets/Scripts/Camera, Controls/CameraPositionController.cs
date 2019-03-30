using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionController : MonoBehaviour {

	/*
	Script for changing cameras

	Takes in coordinates for locations for two different locations
	 */
	float xdefault;
	float ydefault;
	float zdefault;

	float xworld;
	float yworld;
	float zworld;

	bool onMain = true;
	public int selected = 0;

	void Start () {
		xdefault = 0;
		ydefault = -1.3f;
		zdefault = 0;

		xworld = 0;
		yworld = 2.3f;
		zworld = -5.2f;

		//Default camera position (in center of base)
		transform.position = new Vector3(xdefault, ydefault, zdefault);
	}
	
	
	void Update () {
		
	}

	//On camera switch
	public void switchCameras()
	{
		onMain = !onMain;
		if (onMain)
		{
			transform.position = new Vector3(xdefault, ydefault, zdefault);
			selected = 0;
		}
		else
		{
			transform.position = new Vector3(xworld, yworld, zworld);
			selected = 1;
		}
	}
}

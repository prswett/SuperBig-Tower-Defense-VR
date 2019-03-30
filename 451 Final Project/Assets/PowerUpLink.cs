using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpLink : MonoBehaviour {

	
	public SceneNode linked;
	public NodePrimitive node;
	public TowerPowerups power;

	// Use this for initialization
	void Start () {
		transform.localScale = node.transform.localScale + new Vector3(0, node.transform.localScale.y, 0);
	}
	
	//Our position, rotation, and scale are the same as linked node (except height is doubled)
	void Update () {
        transform.position = node.matrix.GetColumn(3);
        transform.up = linked.transform.up;
        
	}
}

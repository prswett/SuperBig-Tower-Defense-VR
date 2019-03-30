using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastLink : MonoBehaviour {

	/*
	Link class solely used for letting raycasting grab the right objects
	(Since unity has no idea about the actual transforms of towers)
	 */
    public SceneNode linked;
    public NodePrimitive node;

	// Use this for initialization
	void Start () {
        transform.localScale = node.transform.localScale;
	}
	
	//Our position, rotation, and scale are the same as linked node (except height is doubled)
	void Update () {
        transform.position = node.matrix.GetColumn(3);
        transform.up = linked.transform.up;
	}
}

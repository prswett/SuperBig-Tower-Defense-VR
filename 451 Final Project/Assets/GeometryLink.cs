using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeometryLink : MonoBehaviour {

	// Use this for initialization
	public SceneNode linked;
	public NodePrimitive node;

	// Use this for initialization
	void Start () {
		transform.localScale = new Vector3(node.transform.localScale.x + .05f, node.transform.localScale.y * 2f, node.transform.localScale.z + .05f);
	}
	
	//Our position, rotation, and scale are the same as linked node (except height is doubled)
	void Update () {
        transform.position = node.matrix.GetColumn(3);
        transform.up = linked.transform.up;
	}
}

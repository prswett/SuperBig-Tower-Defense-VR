using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCamera : MonoBehaviour {

	/*
	Test camera for looking at what the gun sees
	 */
	public NodePrimitive node;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = node.matrix.GetColumn(3);
		transform.forward = node.gameObject.transform.up;
	}
}

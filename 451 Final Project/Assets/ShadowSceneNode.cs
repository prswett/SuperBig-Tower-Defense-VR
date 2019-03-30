using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSceneNode : MonoBehaviour {

	public GameObject board;
	public NodePrimitive node;
	void Awake()
	{
		board = GameObject.Find("Base");
	}

	Vector3 n;
	float h;
	float d;
	void Start () {
		n = -board.transform.forward;
		d = Vector3.Dot(n, board.transform.position);
		transform.localScale = new Vector3(.1f, .002f, .1f);
		
	}
	
	// Update is called once per frame
	void Update () {
		h = Vector3.Dot(node.matrix.GetColumn(3), n) - d;
		transform.position = node.matrix.GetColumn(3);
		transform.position -= (n * h);
		transform.up = Vector3.up;
	}
}

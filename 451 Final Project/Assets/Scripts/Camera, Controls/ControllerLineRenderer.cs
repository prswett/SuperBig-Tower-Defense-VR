using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerLineRenderer : MonoBehaviour {

    LineRenderer r;
    public bool left;
    private void Awake()
    {
        r = GetComponent<LineRenderer>();
    }
    void Start () {
		Renderer temp = r.GetComponent<Renderer>();
        Material m = temp.material;
        if (left)
        {
            m.color = Color.blue;
        }
        else
        {
            m.color = Color.red;
        }
	}
	
	// Update is called once per frame
	void Update () {
        r.SetPosition(0, transform.position);
        r.SetPosition(1, transform.position + transform.forward * 10);
	}
}

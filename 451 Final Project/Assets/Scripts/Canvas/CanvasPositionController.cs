using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasPositionController : MonoBehaviour {

	/*
	Class for canvas position and size implmeented with VR in
	mind.

	Grabs dimensions of camera far view and changes the canvas accordingly.

	Change this in accordance to needs in VR
	 */
	public Transform targetCamera;
	public Camera selectedCamera;
	public RectTransform rect;
	void Awake()
	{
		rect = GetComponent<RectTransform>();
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		updateCanvas();
	}

	float nearDistance;
	float angle;
	float height;
	float width;
	void updateCanvas()
	{
		nearDistance = selectedCamera.farClipPlane;
		angle = (selectedCamera.fieldOfView * .5f) * Mathf.Deg2Rad;
		height = (Mathf.Tan(angle) * nearDistance);
		width = (height / selectedCamera.pixelHeight) * selectedCamera.pixelWidth;
        rect.sizeDelta = new Vector2(width * .6f, height * .6f);

		transform.position = targetCamera.position + (.8f * targetCamera.forward * nearDistance);
        transform.forward = targetCamera.forward;
	}
}

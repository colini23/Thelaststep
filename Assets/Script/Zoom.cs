using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
	public int zoom = 20;
	public int normal = 60;
	public float smooth = 5;

	private bool isZoomed = false;



	// Use this for initialization
	void LateUpdate()
	{
		if (Input.GetMouseButtonDown(0))
		{
			isZoomed = !isZoomed;
		}

		if (isZoomed)
		{
			GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth);
		}
		else
		{
			GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth);
		}


	}


}

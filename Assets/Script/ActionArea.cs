using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionArea : MonoBehaviour {
	bool inArea;

	public GameObject desactivateObject;

	 Transform wheel;
	public float timeRotation = 1;

	public int keyCount = 3;

	// Use this for initialization
	void Start () {
		wheel = transform;
	}


	// Update is called once per frame
	void Update () {
		if (inArea && (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown("joystick button 2")))
		{
			StartCoroutine ("RotateWheel");
			keyCount--;
			if (keyCount <= 0 && desactivateObject!= null)
				desactivateObject.SetActive (false);
		}
	}

	IEnumerator RotateWheel () {

		for (int i = 0; i < timeRotation/20; i++) {
			wheel.Rotate (0, -15, 0);
			 yield return new WaitForSeconds(timeRotation/20);
		}

	}

	void OnTriggerEnter(Collider player)
	{
		GameController.controller.fKey.enabled = true;
		inArea = true;
	}

	void OnTriggerExit(Collider player)
	{
		GameController.controller.fKey.enabled = false;
		inArea = false;
	}
}

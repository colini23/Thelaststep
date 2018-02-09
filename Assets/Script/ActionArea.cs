using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionArea : MonoBehaviour {
	bool inArea;

	public GameObject desactivateObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (inArea && (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown("joystick button 2")))
		{
			if (desactivateObject!= null)
				desactivateObject.SetActive (false);
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

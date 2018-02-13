using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivarInterrogatorio : MonoBehaviour {
	public GameObject interrogatorioObject;
	public GameObject player;
	public GameObject focusButton;

	void OnTriggerEnter(Collider coll)
	{
		if (coll.tag == "Player") {
			interrogatorioObject.SetActive (true);
			player.SetActive (false);
			FindObjectOfType<UnityEngine.EventSystems.EventSystem> ().SetSelectedGameObject (focusButton);
		}
	}
}

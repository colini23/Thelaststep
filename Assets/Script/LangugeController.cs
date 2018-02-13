using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LangugeController : MonoBehaviour {

	public Toggle engTog;
	public Toggle espTog;

	public static string currentLanguage = "ENG";
	public  string current = "ENG";

	void Awake() {
		if (PlayerPrefs.HasKey ("Language"))
			currentLanguage = PlayerPrefs.GetString ("Language");

		if (engTog != null) {

			if (currentLanguage == "ENG") {
				engTog.isOn = true;
				espTog.isOn = false;

			} else {
				engTog.isOn = false;
				espTog.isOn = true;
			}
		}
	}

	// Use this for initialization
	public void Spanish (bool active) {
		if (active) {
			currentLanguage = "ESP";
			PlayerPrefs.SetString ("Language", currentLanguage);
		}
	}

	public void English (bool active) {
		if (active) {
			currentLanguage = "ENG";
			PlayerPrefs.SetString ("Language", currentLanguage);
		}
	}

	// Update is called once per frame
	void Update () {
		current = currentLanguage;
	}
}

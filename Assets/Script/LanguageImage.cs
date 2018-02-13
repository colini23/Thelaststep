using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageImage : MonoBehaviour {

	 Sprite englishImage; 
	public Sprite spanishImage; 

	string current;

	// Use this for initialization
	void Start () {
		current = LangugeController.currentLanguage;
		englishImage = GetComponent<Image> ().overrideSprite;
		Switch ();
			
	}
	
	// Update is called once per frame
	void Update () {
		if (current != LangugeController.currentLanguage) {
			current = LangugeController.currentLanguage;
			Switch();
		}
		
	}

	void Switch() {
		if (current == "ENG") {
			GetComponent<Image> ().overrideSprite = englishImage;
		} else {
			GetComponent<Image> ().overrideSprite = spanishImage;
		}
	}

}

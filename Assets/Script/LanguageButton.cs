using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageButton : MonoBehaviour {

	Sprite englishImage; 
	Sprite englishImageHigh; 
	public Sprite spanishImage; 
	public Sprite spanishImageHigh; 

	string current;

	// Use this for initialization
	void Start () {
		current = LangugeController.currentLanguage;
		englishImage = GetComponent<Image> ().overrideSprite;

		SpriteState st;
		st = GetComponent<Button> ().spriteState;
		englishImageHigh = st.highlightedSprite;


		Switch ();
			

		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(Click);
	}


	AudioSource audioS;

	void Click(){
		
		audioS = GetComponent<AudioSource>();
		if (audioS==null) {
			
			audioS = gameObject.AddComponent <AudioSource>();
			audioS.clip = Resources.Load("click_menu") as AudioClip;
			audioS.playOnAwake = false;

		}

		audioS.Play();
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
			GetComponent<Image> ().sprite = englishImage;
			SpriteState st;
			st.highlightedSprite = englishImageHigh;
			GetComponent<Button> ().spriteState = st;
		} else {
			GetComponent<Image> ().sprite = spanishImage;
			SpriteState st;
			st.highlightedSprite = spanishImageHigh;
			GetComponent<Button> ().spriteState = st;
		}
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interrogatorio : MonoBehaviour {

	[TextArea]
	public string [] questions;

	[TextArea]
	public string [] answersX3;

	public int[] correctAnswer;

	public Text questionText;
	public Text answer1;
	public Text answer2;
	public Text answer3;

	int index = 0;

	int corectas = 0;
	int incorrectas = 0;

	// Use this for initialization
	void Start () {
		RefresTexts ();

	}

	public void ControlRespuesta(int key) {
		if (key == correctAnswer [index]) {
			corectas++;	
		} else {
			incorrectas++;
		}

		index++;

		if (incorrectas == 2) {
			FindObjectOfType<SceneManager> ().GameOver ();
			return;
		}

		if (corectas == 4) {
			FindObjectOfType<SceneManager> ().YouWin ();
			return;
		}

		RefresTexts ();

	}
	
	// Update is called once per frame
	void RefresTexts (){
		questionText.text = questions [index];
		answer1.text = answersX3 [index];
		answer2.text = answersX3 [index+1];
		answer3.text = answersX3 [index+2];
	}
}

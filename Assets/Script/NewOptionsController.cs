﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.PostProcessing;


public class NewOptionsController : MonoBehaviour {

	public GameObject firstButton;

	public PostProcessingProfile profile;

	float _brillo =0;
	public float brillo{
		get{ 


			return _brillo;
		}
		set{BrilloChange (value);}
	}

    // Use this for initialization
    void OnEnable () {
		FindObjectOfType<UnityEngine.EventSystems.EventSystem> ().SetSelectedGameObject (firstButton);
    }



	public void BrilloChange( float valorBrillo)  {
		ColorGradingModel.BasicSettings basicSettings = new ColorGradingModel.BasicSettings();
		basicSettings.postExposure = valorBrillo;
		basicSettings.saturation = 1;
		basicSettings.contrast = 1;
		ColorGradingModel.Settings settings = profile.colorGrading.settings;
		settings.basic = basicSettings;
		profile.colorGrading.settings =settings;
	}

	public void ChangeQuialityVeryLow () {
        QualitySettings.SetQualityLevel(0, true);
    }

	public void ChangeQuialityLow () {
		QualitySettings.SetQualityLevel(1, true);
	}

	public void ChangeQuialityMedium () {
		QualitySettings.SetQualityLevel(2, true);
	}

	public void ChangeQuialityHight () {
		QualitySettings.SetQualityLevel(3, true);
	}

	public void ChangeQuialityUltra () {
		QualitySettings.SetQualityLevel(4, true);
	}

    public void ChangeResolution640()
	{
		Screen.SetResolution (640, 480, true);
	}

	public void ChangeResolution1024()
	{
		Screen.SetResolution(1024, 768, true);
	}

	public void ChangeResolution1200()
	{
		Screen.SetResolution(1280, 720, true);
	}

	public void ChangeResolution1600()
	{
		Screen.SetResolution(1600, 1200, true);
	}

	public void ChangeResolution1920()
	{
		Screen.SetResolution(1920, 1080, true);
	}
}

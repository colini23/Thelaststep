using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class OptionsController : MonoBehaviour {

    public Dropdown qualitiesDrop;
    public Dropdown resolutionDrop;

    // Use this for initialization
    void Start () {
        string[] names = QualitySettings.names;
        List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();
        int i = 0;
        while (i < names.Length)
        {
            options.Add(new Dropdown.OptionData(names[i]));                
            i++;
        }
        qualitiesDrop.AddOptions(options);
        qualitiesDrop.value = QualitySettings.GetQualityLevel();

        resolutionDrop.captionText.text = Screen.currentResolution.ToString();

        qualitiesDrop.onValueChanged.AddListener(delegate {
            ChangeQuiality();
        });

        resolutionDrop.onValueChanged.AddListener(delegate {
            ChangeResolution();
        });

    }

    // Update is called once per frame
    void ChangeQuiality () {
        QualitySettings.SetQualityLevel(qualitiesDrop.value, true);
    }

    public void ChangeResolution()
    {
        int optionSelected = resolutionDrop.value;

        switch (optionSelected)
        {
            case 0:
                Screen.SetResolution(640, 480, true);
                break;
            case 1:
                Screen.SetResolution(1024, 768, true);
                break;
            case 2:
                Screen.SetResolution(1280, 720, true);
                break;
            case 3:
                Screen.SetResolution(1600, 1200, true);
                break;
            case 4:
                Screen.SetResolution(1920, 1080, true);
                break;
        }
    }
}

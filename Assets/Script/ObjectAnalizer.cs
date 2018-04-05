using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAnalizer : MonoBehaviour {
     GameObject visibleObject;
    public GameObject camara;

    public GameObject[] objects;

    public bool active = false;

	// Use this for initialization
	void Start () {
         visibleObject = null;
        StartCoroutine(Activation(active));
	}
	
	// Update is called once per frame
	void Update () {

        if ((Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyDown("joystick button 7")) && active == true)
        {
            StartCoroutine ( Activation(false));
            GameController.controller.player.SetActive(true);
            GameController.controller.idObjAnalize = -1;
        }

    }

    IEnumerator Activation (bool state)
    {
        camara.SetActive(state);

        yield return null;

        active = state;

    }
    public void ShowObject(int index)
    {
        StartCoroutine(Activation(true));
        if (visibleObject != null)
            visibleObject.SetActive(false);
        objects[index].SetActive(true);
        visibleObject = objects[index];
    }
}

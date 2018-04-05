using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
public class AnalizableObject : MonoBehaviour {

    public int idObjAnalize;

    BoxCollider colliderObject;

	// Use this for initialization
	void Start () {
        colliderObject = GetComponent<BoxCollider>();
        colliderObject.isTrigger = true;


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider player)
    {
        GameController.controller.aKey.enabled = true;
        GameController.controller.idObjAnalize = idObjAnalize;
    }

    void OnTriggerExit(Collider player)
    {
        GameController.controller.aKey.enabled = false;
        GameController.controller.idObjAnalize = -1;

    }
}

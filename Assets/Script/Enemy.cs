using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float distanceDetection = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider player)
    {
        RaycastHit hit;
        if (player.tag == "Player") {
            Vector3 direction = player.transform.position - transform.position;
            if (Physics.Raycast(transform.position, direction* distanceDetection, out hit))
            {
                   if (hit.collider.tag == "Player")
                {
                    FindObjectOfType<SceneController>().GameOver();
                }
            }
        }
        
    }

    void OnCollisionEnter(Collision player)
    {
        RaycastHit hit;
        if (player.gameObject.tag == "Player")
        {
            GetComponent<Animator>().enabled = false;
            transform.LookAt(player.transform.position);
            Vector3 direction = player.transform.position - transform.position;
            if (Physics.Raycast(transform.position, direction * distanceDetection, out hit))
            {
                if (hit.collider.tag == "Player")
                {
                    FindObjectOfType<SceneController>().GameOver();
                }
            }
        }

    }
}

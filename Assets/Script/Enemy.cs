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
					Invoke ("GameOver", 3);
					Camera.main.gameObject.AddComponent<Rigidbody> ();
					Camera.main.gameObject.AddComponent<CapsuleCollider> ();
					Camera.main.gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.HeadBob> ().enabled = false;
					Camera.main.gameObject.transform.Rotate (0, 0, 25);
					hit.collider.enabled = false;
					hit.collider.GetComponent<Rigidbody> ().useGravity = false;
					hit.collider.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController> ().enabled = false;

                }
            }
        }
        
    }

	void GameOver () {
		FindObjectOfType<SceneManager>().GameOver();
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
                    FindObjectOfType<SceneManager>().GameOver();
                }
            }
        }

    }
}

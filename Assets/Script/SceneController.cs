using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Play()
    {
        SceneManager.LoadScene("Level1");
    }


    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void Exit()
    {
        Application.Quit();
    }

    void OnTriggerEnter(Collider player)
    {
        //if (player.tag == "Player")
        //{
            SceneManager.LoadScene("Victory");
        //}

    }
}

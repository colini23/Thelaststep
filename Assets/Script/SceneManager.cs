using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour {
    public bool cursorVisible = true;
	public string nextScene = "Victory";

	// Use this for initialization
	void Start () {
        Cursor.visible = cursorVisible;
        if (cursorVisible)
            Cursor.lockState = CursorLockMode.None;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
    }

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }


    public void GameOver()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }

	public void YouWin()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Victory");
	}

    public void Exit()
    {
        Application.Quit();
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player" || player.tag == "Untagged")
        {
			UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
        }

    }
}

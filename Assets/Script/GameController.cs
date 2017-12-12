using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameStates
{
    init,
    card1,
    card2,
    secretRoomOpen
}

public class GameController : MonoBehaviour {

    public Image card1Image;
    public Image card2Image;
    public Text fKey;
    public Text pauseText;

    public GameObject player;

    public GameStates gameState;

    public static GameController controller;

    bool paused;

    void Awake()
    {
        controller = this;
    }

    // Use this for initialization
    void Start () {
        gameState = GameStates.init;
     }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            paused = !paused;

            Time.timeScale = paused ? 0 : 1;

            pauseText.enabled = paused;
        }
            if (Input.GetKeyDown(KeyCode.F10))
        {
            player.GetComponent<Collider>().isTrigger = true;
            Physics.gravity = Vector3.zero;
            player.tag = "Untagged";
        }

		if (gameState == GameStates.card1)
        {
            card1Image.enabled = true;
        }
        if (gameState == GameStates.card2)
        {
            card2Image.enabled = true;
        }
        if (card2Image.enabled && card1Image.enabled)
        {
            gameState = GameStates.secretRoomOpen;
        }
    }
}

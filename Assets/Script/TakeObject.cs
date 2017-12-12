using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeObject : MonoBehaviour
{
    bool toTake;
    public int cardNumber;

    // Use this for initialization
    void Start()
    { 

    }

    // Update is called once per frame
    void Update()
    {
        if (toTake)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Destroy(gameObject);
                GameController.controller.fKey.enabled = false;
                if (cardNumber == 1)
                    GameController.controller.gameState = GameStates.card1;
                else
                    GameController.controller.gameState = GameStates.card2;
            }
        }
    }

    void OnTriggerEnter(Collider player)
    {
        GameController.controller.fKey.enabled = true;
        toTake = true;
    }

    void OnTriggerExit(Collider player)
    {
        GameController.controller.fKey.enabled = false;
        toTake = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public Transform openPosition;
    public float speed = 1f;
    public bool secretRoom;
    Vector3 destinyPos;
    Vector3 originPos;

    void Start ()
    {
        originPos = transform.position;
    }

    IEnumerator OpenCloseDoor()
    {
        GetComponent<AudioSource>().Play();
        while (Vector3.Distance(transform.position, destinyPos) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destinyPos, speed/100);
            yield return null;
        }
    }

    void OnTriggerEnter(Collider player)
     {

        if (GameController.controller.gameState == GameStates.secretRoomOpen)
        {
            secretRoom = false;

        }

        if (!secretRoom  && player.tag == "Player")
        {
            destinyPos = openPosition.position;
            StartCoroutine("OpenCloseDoor");
        }
     }

     void OnTriggerExit(Collider player)
     {
        if (!secretRoom && player.tag == "Player")
        {
            destinyPos = originPos;
            StartCoroutine("OpenCloseDoor");
        }
    }

}


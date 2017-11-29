using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
   
     public Animation open;
    public Animation close;

     // Use this for initialization
     
       

     void OnTriggerEnter(Collider player)
     {
        open.GetClip("OpeningDoor");
         open.Play();
     }

     void OnTriggerExit(Collider player)
     {
        open.GetClip("ClosingDoor");
        close.Play(); 
     }
}


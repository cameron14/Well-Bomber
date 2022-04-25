using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inGameMenuManager : MonoBehaviour
{
     public GameObject menu; // Assign in inspector
     private bool isMenuVisable;
 
     void Update() {
         if (Input.GetKeyDown("escape")) {
             isMenuVisable = !isMenuVisable;
             menu.SetActive(isMenuVisable);
         }
     }
}

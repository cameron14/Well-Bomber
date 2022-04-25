using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inGameMenuManager : MonoBehaviour
{
    public GameObject menu;
    private bool isMenuVisable;
 
    void Update()
    {
        if (Input.GetKeyDown("escape")) // keybind = "esc"
        {
           isMenuVisable = !isMenuVisable;
           menu.SetActive(isMenuVisable);
        }

    }
}

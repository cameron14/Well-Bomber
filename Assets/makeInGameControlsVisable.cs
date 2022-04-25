using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeInGameControlsVisable : MonoBehaviour
{
    public GameObject controls;
    private bool isControlsVisable;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("menu")) // keybind = "="
        {
            Debug.Log("key = down");
            isControlsVisable = !isControlsVisable;
            controls.SetActive(isControlsVisable);
        }
    }
}

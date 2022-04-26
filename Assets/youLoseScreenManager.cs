using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class youLoseScreenManager : MonoBehaviour
{
    public GameObject youLoseScreen;
    private bool isMenuVisable;
    bool temp = false;
    int counter = 0;


    // Update is called once per frame
    void Update()
    {
        wellTracker youLostVariable = FindObjectOfType<wellTracker>();
        //Debug.Log("youLostVariable.youLost: " + youLostVariable.youLost);
        temp = youLostVariable.youLost;

        if(temp == true && counter < 1)
        {
            isMenuVisable = !isMenuVisable;
            youLoseScreen.SetActive(isMenuVisable);
            counter = counter + 5;
        }

    }
}

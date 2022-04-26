using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class youWinScreenManager : MonoBehaviour
{
    public GameObject youWinScreen;
    private bool isMenuVisable;
    bool temp = false;
    int counter = 0;


    // Update is called once per frame
    void Update()
    {
        wellTracker youWonVariable = FindObjectOfType<wellTracker>();
        //Debug.Log("youWonVariable.youWon: " + youWonVariable.youWon);
        temp = youWonVariable.youWon;

        if(temp == true && counter < 1)
        {
            isMenuVisable = !isMenuVisable;
            youWinScreen.SetActive(isMenuVisable);
            counter = counter + 5;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script for wellBricksDark (1) to make them change to leaking sprite


public class changeToLeak2 : MonoBehaviour
{
    public Sprite leakingBricks;
    public Sprite normalBricks;
    public bool leaking = false;

    void Update()
    {
        
    }


    public void changeToLeakSprite()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = leakingBricks;
        setToLeakStatus(true);
    }



    public bool setToLeakStatus(bool choice)
    {
        if(choice == true)
        {
            leaking = true;
        }
        else{
            leaking = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = normalBricks;


            // set leak now to false    leakNow
            // get counter for the bore2 from wellTracker.cs
            boreManagement2 bore2 = FindObjectOfType<boreManagement2>();
            Debug.Log("bore2 leakNow: " + bore2.leakNow);

        }

        return false;

        
    }

}

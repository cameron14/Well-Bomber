using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boreManagement : MonoBehaviour
{

    public bool moveToWell = true;
    public float speed = 1f; // default speed of tunnel bore - change speed in inspector
    Vector2 endPosition = new Vector2(-50f, 1.63f); // -50f is where the bore stops
    //AudioSource boreNoise;
    bool boreAtWell;
    bool boreAtWellFromWellTracker = false;
    //int boreCounter = 0;
    bool leakNow = false;
    int holdWellPercentage = 0;
    public int counter = 10;




    // Start is called before the first frame update
    void Start()
    {

        // wellTracker _wellTracker = FindObjectOfType<wellTracker>();
        // Debug.Log("_wellTracker.counter: " + _wellTracker.counter);
        // bool counterEquals500 = false;

        // do
        // {
            

        //     if(boreCounter >= 500)
        //     {
        //         boreAtWellFromWellTracker = true;
        //         Debug.Log("boreAtWellFromWellTracker");
        //         counterEquals500 = true;
        //     }

        // } while (counterEquals500 == false);
        


        Debug.Log("boreManagement Start()");

        


    }


    // Update is called once per frame
    void Update()
    {

        // get counter for the bore from wellTracker.cs
        wellTracker _wellTracker = FindObjectOfType<wellTracker>();
        Debug.Log("_wellTracker.counter: " + _wellTracker.counter);
        Debug.Log("_wellPercentage.wellPercentage: " + _wellTracker.wellPercentage);
        holdWellPercentage = _wellTracker.wellPercentage;
        Debug.Log("holdWellPercentage: " + holdWellPercentage);

        if(_wellTracker.counter >= 500)
        {
            boreAtWellFromWellTracker = true;
            Debug.Log("boreAtWellFromWellTracker: " + boreAtWellFromWellTracker);
        }


        isBoreAtWell();

    }



    public bool shouldILeak(bool answer)
    {
        if(holdWellPercentage >= 500 && boreAtWellFromWellTracker == true)
        {
            leakNow = true;
            Debug.Log("leak now@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            return leakNow;
        }
        
        leakNow = false;
        return false;
    }




    public bool hasBoreReachedWell(bool answer1)
    {
        return boreAtWell;
        
    }



    public void callDecreaseWellWater()
    {
        int boreNumber = 1;

        // get counter for the bore from wellTracker.cs
        wellTracker _wellTracker2 = FindObjectOfType<wellTracker>();
        _wellTracker2.decreaseWellWater(boreNumber);

        if (--counter == 0)CancelInvoke("callDecreaseWellWater");
            
    }


    public void isBoreAtWell()
    {

        



        if(transform.position.x == -50f)
        {
            boreAtWell = true;
            //Debug.Log("boreManagment line 46: " + true);

            changeToLeak leak;
            leak = FindObjectOfType<changeToLeak>();
            leak.changeToLeakSprite();


            // set boreAtWell from wellTracker Update() to true


            // set well to decrease from bore damage here. e.g. leak if wellPercentage is >= 1000 && wellPercentage <= 500 && boreCounter >= 500 && not bombed



            bool temp = false;

            shouldILeak(temp);
            Debug.Log("Temp:" + temp);

            // ADD IN BIT ABOUT BOMBINB BORE WHERE!!!!!!
            while(leakNow == true)       //wellPercentage >= 500 && boreAtWellFromWellTracker = true && not bombed)     
            {

                // display what shouldILeak sends
                shouldILeak(temp);
                Debug.Log("Temp:" + temp);
                

                    
                    float x = 15.0f;
                    float y = 30.0f;
                    InvokeRepeating("callDecreaseWellWater", x, y);
                
                break;

                // if(wellPercentage <= 500 || boreAtWellFromWellTracker = false)  // ADD IN BIT ABOUT BOMBINB BORE WHERE!!!!!!
                // {
                //     Debug.Log("Well to empty to leak. ( < 500 )");
                //     break;
                // }
            }

        }
        else
        {
            //Debug.Log("Bore not at well");
        }
    }



    public bool isBoreMoving()
    {
        if(transform.position.x != -42.7f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }



    public bool callBoreNoise()
    {

        bool moving = false;
        moving = isBoreMoving();

        if(moving == true) // transform.position.x != -42.7f && transform.position.x != -50f && 
        {
            //GetComponent<AudioSource> ().Play ();

            // call function to play bore noise
            boreNoiseScript playDrill;
            playDrill = FindObjectOfType<boreNoiseScript>();
            playDrill.playBoreNoise();

        }
        else
        {
            // call function to stop bore noise
            boreNoiseScript stopNoise;
            stopNoise = FindObjectOfType<boreNoiseScript>();
            stopNoise.stopBoreNoise();
        }


        return true;
    }





    // tunnel bores will start coming along when the water level in the well gets to a certain percentage e.g. wellPercentage = 500
    public void moveBore()
    {

        // Move the tunnel bore to the well
        float step = speed * Time.deltaTime;
        

        transform.position = Vector2.MoveTowards(transform.position, endPosition, step);
        isBoreAtWell();
        


        
    }


}
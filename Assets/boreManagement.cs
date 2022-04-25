using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boreManagement : MonoBehaviour
{

    public bool moveToWell = true;
    public float speed = 1f; // default speed of tunnel bore - change speed in inspector
    Vector2 endPosition = new Vector2(-50f, 1.63f); // -50f is where the bore stops
    AudioSource boreNoise1;
    //bool boreAtWell;
    bool boreAtWellFromWellTracker = false;
    //int boreCounter = 0;
    public bool leakNow = false;
    int holdWellPercentage = 0;
    public int counter = 10;
    public bool oneTheMove = false;
    int counterTemp = 0;
    int counterTemp2 = 0;
    public bool soundAlarm = false;


    public bool isBombed = false;


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
        


        //Debug.Log("boreManagement Start()");




        


    }


    // Update is called once per frame
    void Update()
    {

        // get counter for the bore from wellTracker.cs
        wellTracker _wellTracker = FindObjectOfType<wellTracker>();
        //Debug.Log("_wellTracker.counter: " + _wellTracker.counter);
       // Debug.Log("_wellPercentage.wellPercentage: " + _wellTracker.wellPercentage);
        holdWellPercentage = _wellTracker.wellPercentage;
        //Debug.Log("holdWellPercentage: " + holdWellPercentage);

        if(_wellTracker.counter >= 500 && isBombed == false)
        {
            boreAtWellFromWellTracker = true;
           // Debug.Log("boreAtWellFromWellTracker: " + boreAtWellFromWellTracker);
            isBoreAtWell();
        }

        

        while(oneTheMove == true)
        {
        
            if(isBombed == false && counterTemp < 1)
            {
                GetComponent<AudioSource> ().Play ();
                //Debug.Log("playBoreNoise1");

                counterTemp = 5;
            }
            else if(isBombed == true)
            {
                break;
            }
            break;

        }

        
        while(soundAlarm == true)
        {
        
            if(isBombed == true)
            {
                //GetComponent<AudioSource> ().Stop ();
                //Debug.Log("stopBoreNoise1");
                //counterTemp++;
            }
            else if(isBombed == false && counterTemp2 < 1)
            {
                // play warning alarm
                boreAlarmScript alarm = FindObjectOfType<boreAlarmScript>();
                alarm.playBoreNoise();
                counterTemp2 = 5;
            }
            break;

        }



    }




    public void bombBore1(bool blowUp)
    {
        

        blowUp = true;
        // change isBombed to true;
        isBombed = blowUp;
        Debug.Log("Bore1 is destroyed " + isBombed);

        
        // change spirte to blowen up bore
        bore1bombedSpriteChange kaboom;
        kaboom = FindObjectOfType<bore1bombedSpriteChange>();
        kaboom.changeToBombedSprite();



        

        // change leaking to false;


        // update isBoreAtWell
        wellTracker _wellTrackerBoreAtWell = FindObjectOfType<wellTracker>();
        _wellTrackerBoreAtWell.boreAtWell = false;
       // Debug.Log("boreManagement -> _wellTracker.boreAtWell status: " + _wellTrackerBoreAtWell.boreAtWell);


    }




    public bool isBoreBombed(bool isBombed)
    {
        return true;
    }



    public bool shouldILeak(bool answer)
    {
        if(holdWellPercentage >= 500 && boreAtWellFromWellTracker == true)
        {
            leakNow = true;
           // Debug.Log("leak now@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            return leakNow;
        }
        
        leakNow = false;
        return false;
    }




    public bool hasBoreReachedWell(bool answer1)
    {
        return boreAtWellFromWellTracker;
        
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

        if(transform.position.x == -50f && isBombed == false)
        {
            //boreAtWell = true;
            //Debug.Log("boreManagment line 46: " + true);

            changeToLeak leak;
            leak = FindObjectOfType<changeToLeak>();
            leak.changeToLeakSprite();


            // set boreAtWell from wellTracker Update() to true


            // set well to decrease from bore damage here. e.g. leak if wellPercentage is >= 1000 && wellPercentage <= 500 && boreCounter >= 500 && not bombed



            bool temp = false;

            shouldILeak(temp);
           // Debug.Log("Temp:" + temp);

            // ADD IN BIT ABOUT BOMBINB BORE WHERE!!!!!!
            while(leakNow == true)       //wellPercentage >= 500 && boreAtWellFromWellTracker = true && not bombed)     
            {

                // display what shouldILeak sends
                shouldILeak(temp);
               // Debug.Log("Temp:" + temp);
                

                    
                    float x = 10.0f;
                    float y = 10.0f;
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



    // public void callBoreNoise()
    // {

    //     bool moving = false;
    //     moving = isBoreMoving();

    //     if(moving == true && isBombed != false)  // transform.position.x != -42.7f && transform.position.x != -50f && 
    //     {
    //         //GetComponent<AudioSource> ().Play ();

    //         // call function to play bore noise
    //         boreNoiseScript playDrill;
    //         playDrill = FindObjectOfType<boreNoiseScript>();
    //         playDrill.playBoreNoise();

    //     }
    //     else
    //     {
    //         // call function to stop bore noise
    //         boreNoiseScript stopNoise;
    //         stopNoise = FindObjectOfType<boreNoiseScript>();
    //         stopNoise.stopBoreNoise();
    //     }


        
    // }





    // tunnel bores will start coming along when the water level in the well gets to a certain percentage e.g. wellPercentage = 500
    public void moveBore()
    {

        soundAlarm = true;
        oneTheMove = true;
        // Move the tunnel bore to the well
        float step = speed * Time.deltaTime;
        

        transform.position = Vector2.MoveTowards(transform.position, endPosition, step);
        //callBoreNoise();
        isBoreAtWell();
        


        
    }


}
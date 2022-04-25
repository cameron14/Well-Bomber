using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Threading;


public class wellTracker : MonoBehaviour
{
    public int wellPercentage;
    public float startingLevel = 9.0f;  // set this number in the inspector to set the waters starting height 
                                        // startingLevel value can be from -10 (bottom) to 0 (top)
    AudioSource waterPouring;
    public int boreStartsMovingPercentage = 500;
    public int bore2StartsMovingPercentage = 400;
    public bool boreAtWell;
    public bool bore2AtWell;
    bool tempAnswer;
    bool tempAnswer2;
    public int counter = 0;
    public int counter2 = 0;


    // return bore counters
    public int boreCounterGiver(int counterFromGiver)
    {
        return counter;
    }
    public int bore2CounterGiver(int counterFromGiver)
    {
        return counter2;
    }


    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(0f, startingLevel, 0); 

    }

    // Update is called once per frame
    void Update()
    {
        // start moving tunnel bore
        if (wellPercentage >= boreStartsMovingPercentage && boreAtWell == false && counter <= 500) // boreStartsMovingPercentage == wellPercentage ||
        {
            // call tunnel bore to start moving towards the well
            boreManagement callBore;
            callBore = FindObjectOfType<boreManagement>();
            callBore.moveBore();

            // get wellPercentage after increase from wellTracker and display it in console
            boreManagement findOutIfBoreHasReachedWellYet;
            findOutIfBoreHasReachedWellYet = FindObjectOfType<boreManagement>();
            findOutIfBoreHasReachedWellYet.hasBoreReachedWell(tempAnswer);
            
            boreAtWell = tempAnswer;
            //("has bore reached well yet: " + boreAtWell);
            counter++;
            //Debug.Log("Counter: " + counter);
            // boreNoiseScript playDrill;
            // playDrill = FindObjectOfType<boreNoiseScript>();
            // playDrill.playBoreNoise();

        }

        // start moving tunnel bore 2
        if (wellPercentage >= bore2StartsMovingPercentage && bore2AtWell == false && counter2 <= 500) // boreStartsMovingPercentage == wellPercentage ||
        {
            // call tunnel bore to start moving towards the well
            boreManagement2 callBore;
            callBore = FindObjectOfType<boreManagement2>();
            callBore.moveBore();

            // get wellPercentage after increase from wellTracker and display it in console
            boreManagement2 findOutIfBoreHasReachedWellYet;
            findOutIfBoreHasReachedWellYet = FindObjectOfType<boreManagement2>();
            findOutIfBoreHasReachedWellYet.hasBoreReachedWell(tempAnswer2);
            
            bore2AtWell = tempAnswer2;
            //("has bore reached well yet: " + boreAtWell);
            counter2++;
            //Debug.Log("Counter: " + counter);

        }
        int temp = 0;
        decreaseWellWater(temp);

    }


    // return wellPercentage
    public int wellPercentageGiver(int WellPercentageFromGiver)
    {
        int currentWellPercentage;
        currentWellPercentage = wellPercentage;

        return currentWellPercentage;
    }


    // set new wellPercentage after user increases it with the barrel
    public void wellPercentageSetter(int barrel_fullPercentage)
    {
        wellPercentage = wellPercentage + barrel_fullPercentage;
        //Debug.Log("NEW WELL PERCENTAGE!!!!!! = " + wellPercentage);

        increaseWellWater(barrel_fullPercentage);

        // level is won if wellPercentageAfterIncrease is 1000 or more
        // USE THE INCREASE WELLPERCENTAGE LINE BELOW TO INCREASE GAME DIFFICULTY
        if (wellPercentage == 1000 || wellPercentage >= 1000)
        {
            Debug.Log("Well FULL, you win!!!");
        
        }
    }


    // increase well water image height and wellPercentage
    public void increaseWellWater(int barrel_fullPercentage)
    {
        Debug.Log("increaseWellWater -> barrel_fullPercentage: " + barrel_fullPercentage);

        float floating_barrel_fullPercentage = barrel_fullPercentage;
        //Debug.Log("increaseWellWater -> floating_barrel_fullPercentage: " + floating_barrel_fullPercentage);

        float tempNum = floating_barrel_fullPercentage / 10;
        float tempNum2 = tempNum / 10;
        
       // Debug.Log("increaseWellWater -> tempNum: " + tempNum2);

        GetComponent<AudioSource> ().Play ();
        //Thread.Sleep(1500);
        
        transform.Translate(0f, tempNum2, 0); 
        //Debug.Log("tempIncrease after image update: " + tempIncrease);
    }


    // decrease well water image height
    public void decreaseWellWater(int boreNumber)
    {
       // Debug.Log("int boreNumber: " + boreNumber);

        if(boreNumber == 1)
        {
            if(wellPercentage >= 600)
            {
                wellPercentage = wellPercentage - 100;
                transform.Translate(0f, -1f, 0); 
            } 
        }

        if(boreNumber == 2)
        {
            if(wellPercentage >= 1 && wellPercentage <= 500)
            {
                wellPercentage = wellPercentage - 100;
                transform.Translate(0f, -1f, 0); 
            } 
        }

        if (wellPercentage == 0)
        {
            Debug.Log("You lose! Good day sir!");
        
        }

    }



}
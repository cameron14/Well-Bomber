using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boreManagement : MonoBehaviour
{

    public bool moveToWell = true;
    public float speed = 1f; // default speed of tunnel bore - change speed in inspector
    Vector2 endPosition = new Vector2(-50f, 1.63f); // -50f is where the bore stops
    //AudioSource boreNoise;




    // Start is called before the first frame update
    void Start()
    {


    }


    public void isBoreAtWell()
    {
        bool yesAtWell = false;

        if(transform.position.x == -50f)
        {
            yesAtWell = true;
            Debug.Log("Bore at well :)");

            changeToLeak leak;
            leak = FindObjectOfType<changeToLeak>();
            leak.changeToLeakSprite();

            // while(//wellPercentage >= 500 && yesAtWell = true && not bombed)
            // {
            //     // every 10 seconds
            //         //decreaseWellWater()

                    // if(wellPercentage <= 500 && not bombed)
                    // {
                    //     //do nothing
                    // }
            // }

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


    // Update is called once per frame
    void Update()
    {
        //moveBore();
        isBoreAtWell();

    }


    // tunnel bores will start coming along when the water level in the well gets to a certain percentage e.g. wellPercentage = 500
    public void moveBore()
    {

        // Move the tunnel bore to the well
        float step = speed * Time.deltaTime;
        

        transform.position = Vector2.MoveTowards(transform.position, endPosition, step);

        


        
    }


}

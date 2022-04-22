using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boreManagement : MonoBehaviour
{

    public bool moveToWell = true;
    public float speed = 1f; // default speed of tunnel bore - change speed in inspector
    Vector2 endPosition = new Vector2(-50f, 1.63f); // -50f is where the bore stops
    AudioSource boreNoise;

    public bool alive = false;



    // Start is called before the first frame update
    void Start()
    {
        alive = true;

        if(alive == true) // transform.position.x != -42.7f && transform.position.x != -50f && 
        {
            GetComponent<AudioSource> ().Play ();
        }
        else
        {
            GetComponent<AudioSource> ().Pause ();
        }
    }

    // Update is called once per frame
    void Update()
    {

        //moveBore();

    }


    // tunnel bores will start coming along when the water level in the well gets to a certain percentage e.g. wellPercentage = 500
    public void moveBore()
    {

        // Move the tunnel bore to the well
        float step = speed * Time.deltaTime;
        

        transform.position = Vector2.MoveTowards(transform.position, endPosition, step);
        
    }


}

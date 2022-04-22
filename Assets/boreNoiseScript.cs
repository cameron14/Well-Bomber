using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boreNoiseScript : MonoBehaviour
{

    AudioSource boreNoise;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void playBoreNoise()
    {
        GetComponent<AudioSource> ().Play ();
        Debug.Log("playBoreNoise");
    }

    public void stopBoreNoise()
    {
        GetComponent<AudioSource> ().Stop ();
    }

}

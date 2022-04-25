using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bricksNoiseScript : MonoBehaviour
{
    AudioSource bricks;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void playBricksNoise()
    {
        GetComponent<AudioSource> ().Play ();
        Debug.Log("play bricks");
    }

    public void stopBricksNoise()
    {
        GetComponent<AudioSource> ().Stop ();
        Debug.Log("play brick");
    }
}

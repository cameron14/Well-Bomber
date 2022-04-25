using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombNoiseScript : MonoBehaviour
{
    AudioSource explosion;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void playBombNoise()
    {
        GetComponent<AudioSource> ().Play ();
        Debug.Log("play explostion");
    }

    public void stopBombNoise()
    {
        GetComponent<AudioSource> ().Stop ();
        Debug.Log("play explosion");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterPumpNoiseScript : MonoBehaviour
{
    AudioSource pumpNoise;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void playPumpNoise()
    {
        GetComponent<AudioSource> ().Play ();
        Debug.Log("play explostion");
    }

    public void stopPumpNoise()
    {
        GetComponent<AudioSource> ().Stop ();
        Debug.Log("play explosion");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addItemNoise : MonoBehaviour
{
    AudioSource clickNoise;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void playAddNoise()
    {
        GetComponent<AudioSource> ().Play ();
        Debug.Log("play add");
    }

    public void stopAddNoise()
    {
        GetComponent<AudioSource> ().Stop ();
        Debug.Log("play add");
    }
}

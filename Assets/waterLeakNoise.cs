using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterLeakNoise : MonoBehaviour
{
    AudioSource leak;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void playLeakNoise()
    {
        GetComponent<AudioSource> ().Play ();
        Debug.Log("play leak");
    }

    public void stopLeakNoise()
    {
        GetComponent<AudioSource> ().Stop ();
        Debug.Log("stop leak");
    }
}

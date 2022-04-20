using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wellTracker : MonoBehaviour
{

    public int increase = 5;
    public int decrease = -5;



    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(0f, -10f, 0);       
    }

    // Update is called once per frame
    void Update()
    {
                
    }


    // increase well water image height
    public void increaseWellWater()
    {
        transform.Translate(0f, increase, 0); 
    }


    // decrease well water image height
    public void decreaseWellWater()
    {
        transform.Translate(0f, decrease, 0); 
    }



}

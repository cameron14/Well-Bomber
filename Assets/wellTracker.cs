using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wellTracker : MonoBehaviour
{

    public int increase = 100;
    public int decrease = -100;



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
    public void increaseWellWater(int tempBarrelNum)
    {
        //tempBarrelNum = tempBarrelNum / 10;
        Debug.Log("tempBarrelNum: " + tempBarrelNum);

        int tempIncrease = increase / tempBarrelNum;
        Debug.Log("tempIncrease: " + tempIncrease);

        transform.Translate(0f, tempIncrease, 0); 
    }


    // decrease well water image height
    public void decreaseWellWater()
    {
        transform.Translate(0f, decrease, 0); 
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wellTracker : MonoBehaviour
{
    public int wellPercentage;

    public float startingLevel = -5.0f;  // set this number in the inspector to set the waters starting height

    public float increase = 1.0f;  // set this number in the inspector to set the waters starting height
                                    // make sure and set the wellPercentage in the inspector under "well" in the hierarchy as well
    //public int decrease = -100;



    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(0f, increase, 0);       
    }

    // Update is called once per frame
    void Update()
    {
                
    }


    // return wellPercentage
    public int wellPercentageGiver(int WellPercentageFromGiver)
    {
        int currentWellPercentage;
        currentWellPercentage = wellPercentage;

        return currentWellPercentage;
    }


    // set new wellPercentage after user increases it with the barrel
    public void wellPercentageSetter(int newWellPercentage)
    {
        wellPercentage = wellPercentage + newWellPercentage;
        Debug.Log("NEW WELL PERCENTAGE!!!!!! = " + wellPercentage);



        // level is won if wellPercentageAfterIncrease is 1000 or more
        // USE THE INCREASE WELLPERCENTAGE LINE BELOW TO INCREASE GAME DIFFICULTY
        if (wellPercentage == 1000 || wellPercentage >= 1000)
        {
            Debug.Log("Well FULL, you win!!!");
        
        }
    }




    // increase well water image height and wellPercentage
    public void increaseWellWater(int tempBarrelNum)
    {
        
        //Debug.Log("tempBarrelNum: " + tempBarrelNum);

        int tempIncrease = tempBarrelNum;
        Debug.Log("tempIncrease: " + tempIncrease);

        transform.Translate(0f, 1f, 0); 
        //Debug.Log("tempIncrease after image update: " + tempIncrease);
    }


    // decrease well water image height
    public void decreaseWellWater()
    {
        transform.Translate(0f, -1f, 0); 
    }



}

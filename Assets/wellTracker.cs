using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wellTracker : MonoBehaviour
{
    public int wellPercentage;

    public float startingLevel = 9.0f;  // set this number in the inspector to set the waters starting height 
                                        // startingLevel value can be from -10 (bottom) to 0 (top)
                                        // (might not actually do anyhting idk but the well seems to work if you dont touch it)



    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(0f, startingLevel, 0);       
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
    public void wellPercentageSetter(int barrel_fullPercentage)
    {
        wellPercentage = wellPercentage + barrel_fullPercentage;
        Debug.Log("NEW WELL PERCENTAGE!!!!!! = " + wellPercentage);

        increaseWellWater(barrel_fullPercentage);

        // level is won if wellPercentageAfterIncrease is 1000 or more
        // USE THE INCREASE WELLPERCENTAGE LINE BELOW TO INCREASE GAME DIFFICULTY
        if (wellPercentage == 1000 || wellPercentage >= 1000)
        {
            Debug.Log("Well FULL, you win!!!");
        
        }
    }




    // increase well water image height and wellPercentage
    public void increaseWellWater(int barrel_fullPercentage)
    {
        Debug.Log("increaseWellWater -> barrel_fullPercentage: " + barrel_fullPercentage);

        float floating_barrel_fullPercentage = barrel_fullPercentage;
        //Debug.Log("increaseWellWater -> floating_barrel_fullPercentage: " + floating_barrel_fullPercentage);



        float tempNum = floating_barrel_fullPercentage / 10;
        float tempNum2 = tempNum / 10;
        
        Debug.Log("increaseWellWater -> tempNum: " + tempNum2);



        transform.Translate(0f, tempNum2, 0); 
        //Debug.Log("tempIncrease after image update: " + tempIncrease);
    }


    // decrease well water image height
    public void decreaseWellWater()
    {
        wellPercentage = wellPercentage - 100;
        transform.Translate(0f, -1f, 0); 
    }



}

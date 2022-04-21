using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    // change these comments!!!
    public bool inventory;  // if true this object can be store in inventory
    public bool canBeFilled; // if true this object can be used to store water
    public int fullPercentage = 0; // how full of water is the barrel is
    public bool waterPump; // if true this is the water pump and it can fill the barrel
    public bool well; // if true this is the big well on the left of the screen
    //public int wellPercentage = 0; // how full of water the well is
    public GameObject itemRequiredToWork; // has to be set to the barrel for the water pump to work (first slot in inventory array)




    public void DoInteraction()
    {
        gameObject.SetActive(false);
    }

}

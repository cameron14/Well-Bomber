using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    // change these comments!!!
    public bool inventory;  // if true this object can be store in inventory
    public bool canBeFilled; // if true this object can be used to store water
    public int fullPercentage = 0; // how full of water is the object

    public playerInventory tempItem;



    public void DoInteraction()
    {
        gameObject.SetActive(false);
    }

    public void DoInteractionShow()
    {
        gameObject.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class playerInventory : MonoBehaviour
{
    // create inventory array with space for 1 item
    public GameObject[] inventory = new GameObject[2];
    public Image[] inventorySprites = new Image[2];


    // add an item to the inventory array
    public void Add(GameObject item)
    {
        bool itemAdded = false;

        // check if there is already an item in the players inventory
        for(int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;

                // update inventory UI
                inventorySprites[i].overrideSprite = item.GetComponent<SpriteRenderer>().sprite;

                Debug.Log(item.name + " was added to players inventory");
                itemAdded = true;
                // do something with the object
                item.SendMessage("DoInteraction");
                break;
            }
        }

        // players inventory is full
        if (!itemAdded)
        {
            Debug.Log("Players inventory is full - item not added");
        }
    }


    // Remove item from inventory
    public void Remove()
    {
        bool itemRemoved = false;


        if(inventory[1] != null)
        {
            inventory[1] = null;
            itemRemoved = true;
            Debug.Log("The item was removed from the players inventory");

            // update inventory UI
            inventorySprites[1].overrideSprite = null;

            //item2.SendMessage("DoInteractionShow");
        }

        if(!itemRemoved)
        {
            Debug.Log("Item NOT removed from players inventory or no item in inventory to begin with");
        }

    }


    // increase barrel fullpercentage
    public bool barrelIncrease(GameObject findBarrel)
    {
        // check to see if barrel is in inventory[0]
        if(inventory[0] == findBarrel)
        {
            // found barrel
            // check to see if barrels fullPercentage < 100 (barrel not already full)
            if(inventory[0].GetComponent<InteractionObject>().fullPercentage < 100)
            {
                // Display barrel fullPercentage before increase
                Debug.Log("inventory[0] full percentage before increase attempt: " + inventory[0].GetComponent<InteractionObject>().fullPercentage);    

                // Delay increase fullPercentage command to prevent user spamming interact key
                Thread.Sleep(1500);

                // Increase barrel fullPercentage by 10
                inventory[0].GetComponent<InteractionObject>().fullPercentage = inventory[0].GetComponent<InteractionObject>().fullPercentage + 50;

                // Display barrel fullPercentage after increase
                Debug.Log("inventory[0] full percentage after increase attempt: " + inventory[0].GetComponent<InteractionObject>().fullPercentage);

                return true;
            }
            else
            {
                Debug.Log("Barrel is already 100% full.");
                return false;
            }       
        }
        else // did not find barrel
        {
            Debug.Log("Did not find barrel in inventory[0]");
            return false;
        }
    }


    // decrease barrel fullpercentage and increase wellPercentage
    public bool barrelDecrease(GameObject findBarrel)
    {
        // check to see if barrel is in inventory[0]
        if(inventory[0] == findBarrel)
        {

            // BARREL EMPTY CHECK
            // found barrel
            // check to see if barrels fullPercentage > 0 (barrel not already empty)
            if(inventory[0].GetComponent<InteractionObject>().fullPercentage > 0)
            {

                // Display barrel fullPercentage before decrease attempt
                Debug.Log("inventory[0] full percentage before decrease attempt: " + inventory[0].GetComponent<InteractionObject>().fullPercentage);    

                // Delay decrease fullPercentage command to prevent user spamming interact key
                Thread.Sleep(1000);


                // get current wellPercentage from wellTracker
                //int WellPercentageFromGiver = 0;

                //wellTracker well_currentPercentage;

                //well_currentPercentage = FindObjectOfType<wellTracker>();

               // well_currentPercentage.wellPercentageGiver(WellPercentageFromGiver);


                // display current variables values
                int barrel_fullPercentage = inventory[0].GetComponent<InteractionObject>().fullPercentage;
                //Debug.Log("barrel_fullPercentage = " + barrel_fullPercentage);
                //Debug.Log("WellPercentageFromGiver = " + WellPercentageFromGiver);
                
                //int barrel_plus_well = barrel_fullPercentage + WellPercentageFromGiver;
                //Debug.Log("barrel_plus_well = " + barrel_plus_well);
                
                


                // increase wellPercentage
                wellTracker setNewWellPercentage;
                setNewWellPercentage = FindObjectOfType<wellTracker>();
                setNewWellPercentage.wellPercentageSetter(barrel_fullPercentage);






                // int tempBarrelNum = inventory[0].GetComponent<InteractionObject>().fullPercentage;

                // // increase height of well water image
                // wellTracker wellImage;
                // wellImage = FindObjectOfType<wellTracker>();
                // wellImage.increaseWellWater(tempBarrelNum);




                // get wellPercentage after increase from wellTracker
                // and display it in console
                int wellPercentageAfterIncrease = 0;
                wellTracker well_newPercentage;
                well_newPercentage = FindObjectOfType<wellTracker>();
                well_newPercentage.wellPercentageGiver(wellPercentageAfterIncrease);
                Debug.Log("wellPercentage (wellTracker.cs) after increase attempt: " + wellPercentageAfterIncrease);




                // Decrease barrel fullPercentage to 0
                inventory[0].GetComponent<InteractionObject>().fullPercentage = inventory[0].GetComponent<InteractionObject>().fullPercentage - inventory[0].GetComponent<InteractionObject>().fullPercentage;

                // Display barrel fullPercentage after increase
                Debug.Log("inventory[0] full percentage after decrease attempt: " + inventory[0].GetComponent<InteractionObject>().fullPercentage);






               
                return true;
            }
            else
            {
                Debug.Log("Barrel is already empty.");
                return false;
            }       
        }
        else // did not find barrel
        {
            Debug.Log("Did not find barrel in inventory[0]");
            return false;
        }
    }






    // function to check if user has the barrel in their inventory and
    // it has water in it
    public bool barrelCheck(GameObject findBarrel)
    {
        if(inventory[0] == findBarrel)
        {
            // barrel found
            // check to see if barrel has water in it
            if(inventory[0].GetComponent<InteractionObject>().fullPercentage > 0)
            {
                // barrel has water in it
                Debug.Log("Barrel has water in it.");
                return true;
            }
            else
            {
                Debug.Log("Barrel has NO water in it.");
                return false;
            }
        }
        else
        {
            // 404 barrel not found
            Debug.Log("404 barrel not found");
            return false;
        }
    }


    // public bool wellCheck(GameObject wellPercentage)
    // {
    //     if( )
    // }





    // public void topUpBarrel()
    // {
    //     if(item.fullPercentage < 100)
    //     {
    //         item.fullPercentage  = fullPercentage + 10;
    //         Debug.Log("Barrel fullPercentage + 10");
    //     }
    //     else
    //     {
    //         Debug.Log("Barrel already full");
    //     }

    // }


}

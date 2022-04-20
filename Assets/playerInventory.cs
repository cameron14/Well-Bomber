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
                inventory[0].GetComponent<InteractionObject>().fullPercentage = inventory[0].GetComponent<InteractionObject>().fullPercentage + 10;

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
            // found barrel
            // check to see if barrels fullPercentage > 0 (barrel not already empty)
            if(inventory[0].GetComponent<InteractionObject>().fullPercentage > 0)
            {
                // Display barrel fullPercentage before increase
                Debug.Log("inventory[0] full percentage before decrease attempt: " + inventory[0].GetComponent<InteractionObject>().fullPercentage);    

                // Delay decrease fullPercentage command to prevent user spamming interact key
                Thread.Sleep(1000);



                // increase wellPercentage
                inventory[0].GetComponent<InteractionObject>().wellPercentage = inventory[0].GetComponent<InteractionObject>().wellPercentage + inventory[0].GetComponent<InteractionObject>().fullPercentage;



                // Decrease barrel fullPercentage by 10
                inventory[0].GetComponent<InteractionObject>().fullPercentage = inventory[0].GetComponent<InteractionObject>().fullPercentage - inventory[0].GetComponent<InteractionObject>().fullPercentage;

                // Display barrel fullPercentage after increase
                Debug.Log("inventory[0] full percentage after decrease attempt: " + inventory[0].GetComponent<InteractionObject>().fullPercentage);




                // Display barrel fullPercentage after increase
                Debug.Log("wellPercentage after increase attempt: " + inventory[0].GetComponent<InteractionObject>().wellPercentage);


                // increase height of well water image
                //wellTracker.increaseWellWater();


                // USE THE INCREASE WELLPERCENTAGE LINE BELOW TO INCREASE GAME DIFFICULTY
                if (inventory[0].GetComponent<InteractionObject>().wellPercentage == 1000)
                {
                    Debug.Log("Well FULL, you win!!!");
                }


               
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

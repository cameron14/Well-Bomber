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


    public bool hasBomb = false;
    public bool hasBricks = false;



    public void Update()
    {
        //Debug.Log("hasBomb: " + hasBomb);
    }



    // add an item to the inventory array
    public void Add(GameObject item)
    {
        bool hasItemBeenAddedToInventory = false;

        // check if there is already an item in the players inventory
        for(int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;

                // update inventory UI
                inventorySprites[i].overrideSprite = item.GetComponent<SpriteRenderer>().sprite;

                Debug.Log(item.name + " was added to players inventory");
                hasItemBeenAddedToInventory = true;
                // do something with the object
                item.SendMessage("DoInteraction");
                break;
            }
        }

        // players inventory is full
        if (!hasItemBeenAddedToInventory)
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
                //Debug.Log("inventory[0] full percentage before increase attempt: " + inventory[0].GetComponent<InteractionObject>().fullPercentage);    

                // Delay increase fullPercentage command to prevent user spamming interact key
                //Thread.Sleep(1500);

                // Increase barrel fullPercentage by 10
                inventory[0].GetComponent<InteractionObject>().fullPercentage = inventory[0].GetComponent<InteractionObject>().fullPercentage + 25;

                // Display barrel fullPercentage after increase
                //Debug.Log("inventory[0] full percentage after increase attempt: " + inventory[0].GetComponent<InteractionObject>().fullPercentage);

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
                //Debug.Log("inventory[0] full percentage before decrease attempt: " + inventory[0].GetComponent<InteractionObject>().fullPercentage);    

                // Delay decrease fullPercentage command to prevent user spamming interact key
                //Thread.Sleep(1000);



                int barrel_fullPercentage = inventory[0].GetComponent<InteractionObject>().fullPercentage;



                // increase wellPercentage (fill up well)
                wellTracker setNewWellPercentage;
                setNewWellPercentage = FindObjectOfType<wellTracker>();
                setNewWellPercentage.wellPercentageSetter(barrel_fullPercentage);






                // get wellPercentage after increase from wellTracker and display it in console
                int wellPercentageAfterIncrease = 0;
                wellTracker well_newPercentage;
                well_newPercentage = FindObjectOfType<wellTracker>();
                well_newPercentage.wellPercentageGiver(wellPercentageAfterIncrease);
                //Debug.Log("wellPercentage (wellTracker.cs) after increase attempt: " + wellPercentageAfterIncrease);




                // Decrease barrel fullPercentage to 0 (set barrel to empty)
                inventory[0].GetComponent<InteractionObject>().fullPercentage = inventory[0].GetComponent<InteractionObject>().fullPercentage - inventory[0].GetComponent<InteractionObject>().fullPercentage;

                // Display barrel fullPercentage after increase
                //Debug.Log("inventory[0] full percentage after decrease attempt: " + inventory[0].GetComponent<InteractionObject>().fullPercentage);

               

                if(well_newPercentage.wellPercentageGiver(wellPercentageAfterIncrease) >= 1000)
                {
                    Debug.Log("GAME OVER - YOU WIN!!!");
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
                //Debug.Log("Barrel has water in it.");
                return true;
            }
            else
            {
                //Debug.Log("Barrel has NO water in it.");
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



    // function to check if user has a bomb in their inventory
    public bool bombCheck(GameObject findBomb)
    {
        if(inventory[1] == findBomb)
        {
            // user has a bomb
            //Debug.Log("user has a bomb");
            hasBomb = true;
            return true;
        }
        else
        {
            // 404 bomb not found
            //Debug.Log("user does not have a bomb");
            hasBomb = false;
            return false;
        }
    }




    public void Bomb()
    {
        //bool hasBomb = false;

        //bombCheck(GameObject findBomb);

        if(hasBomb == true)
        {
            //Debug.Log("user has a bomb");

            
            
            // get counter for the bore from wellTracker.cs
            boreManagement bore1Thing = FindObjectOfType<boreManagement>();
            bool tempTempTemp = true;

            bombNoiseScript explosion = FindObjectOfType<bombNoiseScript>();
            explosion.playBombNoise();

            bore1Thing.setOnTheMoveToFalse();

            bore1Thing.bombBore1(tempTempTemp);

        }
        else
        {
           // Debug.Log("user does not have a bomb");
        }

        Remove();
    }



     public void BombBore2()
    {
        //bool hasBomb = false;

        //bombCheck(GameObject findBomb);

        if(hasBomb == true)
        {
            //Debug.Log("user has a bomb");

            
            
            // get counter for the bore from wellTracker.cs
            boreManagement2 bore2Thing = FindObjectOfType<boreManagement2>();
            bool tempTempTempTemp = true;

            bombNoiseScript explosion = FindObjectOfType<bombNoiseScript>();
            explosion.playBombNoise();

            bore2Thing.setOnTheMoveToFalse();

            bore2Thing.bombBore2(tempTempTempTemp);

        }
        else
        {
           // Debug.Log("user does not have a bomb");
        }

        Remove();
    }





    public void useBricks()
    {

  

            Debug.Log("useBricks() -> bricks used");
            
            // get counter for the bore from wellTracker.cs
            changeToLeak wall1 = FindObjectOfType<changeToLeak>();
            changeToLeak2 wall2 = FindObjectOfType<changeToLeak2>();



            wall1.setToLeakStatus(false);
            wall2.setToLeakStatus(false);

        
        Remove();
    }



}

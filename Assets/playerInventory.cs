using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInventory : MonoBehaviour
{
    // create inventory array with space for 1 item
    public GameObject[] inventory = new GameObject[1];



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
            //item2.SendMessage("DoInteractionShow");
        }

        if(!itemRemoved)
        {
            Debug.Log("Item NOT removed from players inventory or no item in inventory to begin with");
        }

    }

}

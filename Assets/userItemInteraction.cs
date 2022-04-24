using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class userItemInteraction : MonoBehaviour
{

    public GameObject currentInteractableObject = null;
    public InteractionObject currentInteractableObjectScript = null;
    public playerInventory inventory;
    //public GameObject currentItemPlayerIsHolding = null;
    //public GameObject mygameobjectvariable = null;


    void Update()
    {
        // pick up item / interact with water pump and well etc
        if (Input.GetButtonDown("PickUp") && currentInteractableObject)
        {
            // check if item can be stored in inventory
            if(currentInteractableObjectScript.inventory)
            {
                inventory.Add(currentInteractableObject);

            }

            // check to see if the object is the water pump
            if (currentInteractableObjectScript.waterPump)
            {
                // check to make sure user has the barrel in first slot in inventory
                // and it is not already full
                if(inventory.barrelIncrease(currentInteractableObjectScript.itemRequiredToWork))
                {
                    // are now able to fill up barrel

                    

                    // \/ FAILED ATTEMPTS BELOW: \/

                    //mygameobjectvariable.GetComponent<playerInventory>().inventory[1];

                    //Debug.Log(inventory);


                    //Debug.Log("Barrel fullPercentage + 10");



                    //currentInteractableObjectScript.itemRequiredToWork.fullPercentage = fullPercentage + 10;
                    //inventory[0].fullPercentage = fullPercentage + 10;
                    //Debug.Log("barrel fullPercentage + 10");
                }
            }

            
            // check to see if the object is the well
            if (currentInteractableObjectScript.well)
            {
                // check to see if barrel is in user inventory and has water in it
                if(inventory.barrelCheck(currentInteractableObjectScript.itemRequiredToWork))
                {
                    //Debug.Log("check to see if the object is the well");

                    // Decrease barrel fullPercentage by 10 every time "Interact" key is pressed
                    inventory.barrelDecrease(currentInteractableObjectScript.itemRequiredToWork);
                    

                    // increase wellPercentage
                    
                }
            }


            if (currentInteractableObjectScript.bomb)
            {
                   inventory.bombCheck(currentInteractableObjectScript.itemRequiredToWork);
            }

            

        }

        // remove item from users inventory
        if (Input.GetButtonDown("Remove") && inventory != null)
        {

            inventory.Remove();
        }



        if (Input.GetButtonDown("Bomb") && inventory != null)
        {
            //inventory.bombCheck(currentInteractableObjectScript.itemRequiredToWork);

            if(inventory.hasBomb == true)
            {
                inventory.Bomb();
            }
            else{
                Debug.Log("User does NOT have a bomb");
            }

            
        }


    }


    // if in range of interactable object set "Current Interactable Object" to name of object
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag ("interactableObject"))
        {
            Debug.Log(other.name);
            currentInteractableObject = other.gameObject;
            currentInteractableObjectScript = currentInteractableObject.GetComponent <InteractionObject> ();
        }
    }

    // not in or leaving range of interactable object set "Current Interactable Object" to null
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag ("interactableObject"))
        {
            if (other.gameObject == currentInteractableObject)
            {
                currentInteractableObject = null;
            }
        }
    }
}

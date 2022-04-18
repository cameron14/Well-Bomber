using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class userItemInteraction : MonoBehaviour
{

    public GameObject currentInteractableObject = null;
    public InteractionObject currentInteractableObjectScript = null;
    public playerInventory inventory;
    //public GameObject currentItemPlayerIsHolding = null;

    void Update()
    {
        if (Input.GetButtonDown("Interact") && currentInteractableObject)
        {
            // check if item can be stored in inventory
            if(currentInteractableObjectScript.inventory)
            {
                inventory.Add(currentInteractableObject);
                //currentItemPlayerIsHolding = currentInteractableObject;
            }

        }


        if (Input.GetButtonDown("Remove") && inventory != null)
        {

            inventory.Remove();
        }

        //Debug.Log(currentItemPlayerIsHolding);


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

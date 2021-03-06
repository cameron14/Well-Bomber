using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryManagment : MonoBehaviour
{
    [SerializeField] private GameObject slotHolder;
    [SerializeField] private itemScript itemToAdd;
    [SerializeField] private itemScript itemToRemove;
    //[SerializeField] KeyCode itemPickUpKeyCode = KeyCode.F;

    public List<itemScript> inventory = new List<itemScript>();

    // Was originally going to have it so the player could hold mulitple items
    // however upon play testing the game I found it made it too easy so reduced
    // the number of items that they could hold down to one. This is why I have
    // code setup to hold multiple items. It worked well when reduced to hold one
    // item so I just kept it the way it was.
    private GameObject[] slots;


    public void Start()
    {
        slots = new GameObject[slotHolder.transform.childCount];
        // Set all the slots
        for (int i = 0; i < slotHolder.transform.childCount; i++)
        {
            slots[i] = slotHolder.transform.GetChild(i).gameObject;
        }

        refreshInventoryUI();
        Add(itemToAdd);
        Remove(itemToRemove);
    }
    

    public void refreshInventoryUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            try {
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = inventory[i].itemIcon;
            }
            catch
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
            }
        }
    }


    // private bool inRangeOfItem;

    // public void Update()
    // {
    //     if (inRangeOfItem && Input.GetKeyDown(itemPickUpKeyCode))
    //     {
    //         Add(itemToAdd);
    //         refreshInventoryUI();
    //     }
    // }


    // public void OnTriggerEnter(Collider other)
    // {
    //     inRangeOfItem = true;
    // }

    // public void OnTriggerExit(Collider other)
    // {
    //     inRangeOfItem = false;
    // }






    public void Add(itemScript item)
    {
        inventory.Add(item);
        refreshInventoryUI();
    }


    public void Remove(itemScript item)
    {
        inventory.Remove(item);
        refreshInventoryUI();
    }

}

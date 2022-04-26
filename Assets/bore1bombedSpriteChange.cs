using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bore1bombedSpriteChange : MonoBehaviour
{
    public Sprite drill_bombed;


    // Update is called once per frame
    void Update()
    {
        
    }


    public void changeToBombedSprite()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = drill_bombed;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script for wellBricksDark (1) to make them change to leaking sprite


public class changeToLeak : MonoBehaviour
{
    public Sprite leakingBricks;

    void Update()
    {
        
    }


    public void changeToLeakSprite()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = leakingBricks;
    }

}

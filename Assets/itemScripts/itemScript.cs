using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class itemScript : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;




    public abstract itemScript getItem();
    public abstract barrelScript getBarrel();
    public abstract bucketScript getbucket();
    public abstract bombScript getBomb();
    public abstract bricksScript getBricks();

}

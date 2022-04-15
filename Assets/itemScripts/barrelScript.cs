using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new barrel script", menuName = "Item/barrel")]

public class barrelScript : itemScript
{
    // values for barrel script only
    public float percentageFull;



    public override itemScript getItem() { return this; }
    public override barrelScript getBarrel() { return this; }
    public override bucketScript getbucket()  { return null; }
    public override bombScript getBomb()  { return null; }
    public override bricksScript getBricks() { return null; }

}

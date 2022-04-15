using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new bucket script", menuName = "Item/bucket")]

public class bucketScript : itemScript
{
    // values for bucket script only
    public float percentageFull;


    public override itemScript getItem() { return this; }
    public override barrelScript getBarrel() { return null; }
    public override bucketScript getbucket()  { return this; }
    public override bombScript getBomb()  { return null; }
    public override bricksScript getBricks() { return null; }
}
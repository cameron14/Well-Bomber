using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new bomb script", menuName = "Item/bomb")]

public class bombScript : itemScript
{
    public override itemScript getItem() { return this; }
    public override barrelScript getBarrel() { return null; }
    public override bucketScript getbucket()  { return null; }
    public override bombScript getBomb()  { return this; }
    public override bricksScript getBricks() { return null; }
}
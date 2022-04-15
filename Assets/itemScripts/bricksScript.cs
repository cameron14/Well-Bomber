using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new bricks script", menuName = "Item/bricks")]

public class bricksScript : itemScript
{
    public override itemScript getItem() { return this; }
    public override barrelScript getBarrel() { return null; }
    public override bucketScript getbucket()  { return null; }
    public override bombScript getBomb()  { return null; }
    public override bricksScript getBricks() { return this; }
}
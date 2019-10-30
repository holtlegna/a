using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : Pickup
{
    public override void Pick(GameObject playerRef)
    {
        playerInfoRef.IncreaseLives();

    }
}

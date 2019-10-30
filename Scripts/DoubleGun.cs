using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleGun : Pickup
{
    public override void Pick(GameObject playerRef)
    {
        playerRef.GetComponent<ShootemUp>().transform.GetChild(0).gameObject.SetActive(false);
        playerRef.GetComponent<ShootemUp>().transform.GetChild(1).gameObject.SetActive(true);
        playerRef.GetComponent<ShootemUp>().transform.GetChild(2).gameObject.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialGrabbable : OVRGrabbable
{
    //This script is taken from Valem's video
    public Transform dial;

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(Vector3.zero, Vector3.zero);

        transform.position = dial.transform.position;
        transform.rotation = dial.transform.rotation;
    }
}

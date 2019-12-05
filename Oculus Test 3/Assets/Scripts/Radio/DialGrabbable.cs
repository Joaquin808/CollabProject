using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialGrabbable : OVRGrabbable
{
    //This script is taken from Valem's video
    public Transform dial;
    float x;

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(Vector3.zero, Vector3.zero);

        Rigidbody rbDial = dial.gameObject.GetComponent<Rigidbody>();
        
        transform.position = dial.transform.position;
        transform.rotation = dial.transform.rotation;

        rbDial.velocity = Vector3.zero;
        rbDial.angularVelocity = Vector3.zero;

    }
}

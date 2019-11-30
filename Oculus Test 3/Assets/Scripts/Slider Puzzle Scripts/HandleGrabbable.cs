using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleGrabbable : OVRGrabbable
{
    public Transform handle;

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(Vector3.zero, Vector3.zero);

        //Resets velocity of grabbable handle after it is released
        Rigidbody rbhandle = handle.GetComponent<Rigidbody>();
        rbhandle.velocity = Vector3.zero;
        rbhandle.angularVelocity = Vector3.zero;

        //Grabbable handle's position resets after it is released
        transform.position = handle.transform.position;
        transform.rotation = handle.transform.rotation;

        //Resets velocity of grabbable handle after it is released 
   
        rbhandle.velocity = Vector3.zero;
        rbhandle.angularVelocity = Vector3.zero;
        
        //lever.GetComponent<Rigidbody>().useGravity = true;
    }

    private void Update()
    {
        //If statement causes grabbable handle to snap back to handle if it gets too far away
        if (Vector3.Distance(handle.position,transform.position) > 0.5f)
        {
            grabbedBy.ForceRelease(this);
        }

    }
}

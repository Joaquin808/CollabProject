using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityControl : MonoBehaviour
{
    public float GravityTimer = 0f;
    public bool UseGravity = false;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().useGravity = UseGravity;
    }

    // Update is called once per frame
    void Update()
    {
        GravityTimer += Time.deltaTime;
        GetComponent<Rigidbody>().useGravity = UseGravity;

        if (gameObject.GetComponent<OVRGrabbable>().isGrabbed)
        {
            UseGravity = true;
        }

        // gives player enough time to grab the object before gravity is enabled and the object falls to the floor
        if (GravityTimer >= 5f)
        {
            UseGravity = true;
            GravityTimer = 0f;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectVisibilityCircuit : MonoBehaviour
{
    public GameObject grabbableCircuit;
    Renderer rend;
    Rigidbody rb;
    public bool SolvedFirstTime = false;
    public bool isBrokenPiece;

    public PowerOn powerScript;

    // Start is called before the first frame update
    void Start()
    {
        if (!isBrokenPiece)
        {
            rend = GetComponent<Renderer>();
            rend.enabled = false;
        }

        if (isBrokenPiece)
        {
            rb = GetComponent<Rigidbody>();
            rb.isKinematic = true;
            rb.useGravity = false;
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Screwdriver" && isBrokenPiece)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }
        if (!isBrokenPiece)
        {
            Objectives ObjectiveScript = GameObject.Find("OVRPlayerController").GetComponent<Objectives>();
            if (ObjectiveScript.ObjectiveNumber == 4 || SolvedFirstTime)
            {
                if (other.gameObject == grabbableCircuit)
                {
                    rend.enabled = true;
                    Destroy(other.gameObject);
                    powerScript.circuitsConnected++;
                    if (powerScript.powerEnabled)
                    {
                        SolvedFirstTime = true;
                    }
                }
            }
        }        
    }
}

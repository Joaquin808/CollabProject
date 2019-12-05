using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenFanScript : MonoBehaviour
{
    Rigidbody rb;

    public bool removed;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    
    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "Welder")
        {
            rb.isKinematic = false;
            rb.useGravity = true;
            removed = true;
        }
    }
}

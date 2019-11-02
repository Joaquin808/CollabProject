using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectVisibilityScript : MonoBehaviour
{
    public GameObject grabbableCircuit;

    Renderer rend; //Calls to circuit 

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == grabbableCircuit)
        {
            rend.enabled = true;
            Destroy(other.gameObject);
        }
    }

    void OnBreak()
    {

    }
}

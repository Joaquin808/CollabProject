using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectVisibilityCircuit : MonoBehaviour
{
    public GameObject grabbableCircuit;
    Renderer rend;

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
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealFanScript : MonoBehaviour
{

    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        rend.enabled = false;
    }

    void OnTriggerEnter(Collision other)
    {
        if (other.gameObject.name == "Welder" && other.gameObject.name == "RealBlade")
        {
            rend.enabled = true;
            if (other.gameObject.name == "RealBlade")
            {
                Destroy(other.gameObject);
            }
        }
    }
}

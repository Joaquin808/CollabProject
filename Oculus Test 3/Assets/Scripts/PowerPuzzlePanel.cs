﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPuzzlePanel : MonoBehaviour
{
    bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.name == "Wrench" || other.gameObject.name == "Wrench(Clone)")
        {
            GameObject.Find("OVRPlayerController").GetComponent<Objectives>().SetNextObjective();
            Destroy(gameObject);
        }
    }
}

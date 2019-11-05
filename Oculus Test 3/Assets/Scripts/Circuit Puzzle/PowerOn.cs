﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerOn : MonoBehaviour
{
    public int circuitsConnected;
    public AudioSource leverClick;
    public bool isBroken = true;
    public bool powerEnabled = false;

    void Start()
    {
        leverClick.GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lever")
        {
            leverClick.Play(0);
            if (circuitsConnected >= 8)
            {
                //Lights come on
                isBroken = false;
                powerEnabled = true;
            }
        }
    }
}

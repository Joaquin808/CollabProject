﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is taken straight from Valem's tutorial
public class FollowPhysics : MonoBehaviour
{
    public Transform target;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.MoveRotation(target.transform.rotation);
    }
}

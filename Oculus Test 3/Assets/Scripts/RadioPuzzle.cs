using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioPuzzle : MonoBehaviour
{
    Objectives objectives;
    AudioSource message;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        objectives = GameObject.Find("OVRPlayerController").GetComponent<Objectives>();
        rb = GameObject.Find("RadioDial").GetComponent<Rigidbody>();
        message = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Sphere" && objectives.ObjectiveNumber == 5)
        {
            rb.freezeRotation = true;
            message.Play(0);
            objectives.SetNextObjective();            
        }
      
    }
}

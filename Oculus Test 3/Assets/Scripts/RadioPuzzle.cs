using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioPuzzle : MonoBehaviour
{
    Objectives objectives;
    AudioSource message;
    Rigidbody rb;
    public bool radioOn = true;
    public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        objectives = GameObject.Find("OVRPlayerController").GetComponent<Objectives>();
        rb = GameObject.Find("RadioDial").GetComponent<Rigidbody>();
        message = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (radioOn)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 68)
        {
            radioOn = false;
            objectives.SetNextObjective();
            timer = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Sphere" && objectives.ObjectiveNumber == 5)
        {
            rb.freezeRotation = true;
            message.Play(0);
            radioOn = true;
        }
      
    }
}

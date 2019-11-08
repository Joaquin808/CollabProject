using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverDoorKey : MonoBehaviour
{
    public GameObject target;

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Lever Cue")
        {
            target.GetComponent<SlidingDoor>().isLocked = false;
        }
    }
}

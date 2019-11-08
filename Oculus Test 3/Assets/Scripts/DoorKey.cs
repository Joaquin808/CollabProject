using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    public GameObject target;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target)
        {
            target.GetComponent<SlidingDoor>().isLocked = false;
            Destroy(gameObject);
        }
    }
}

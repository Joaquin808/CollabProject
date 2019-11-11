using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    public GameObject target;

    void Start()
    {
        if (this.gameObject.name == "PlayerDoorKey Variant(Clone)")
        {
            target = GameObject.Find("PlayerBedroomDoor");
        }
        else if (this.gameObject.name == "GrandpasDoorKey Variant(Clone)")
        {
            target = GameObject.Find("GrandpasDoor");
        }
        else if (this.gameObject.name == "HouseBathroomKey Variant(Clone)")
        {
            target = GameObject.Find("HouseBathroomDoor");
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target)
        {
            if (target == GameObject.Find("HouseBathroomDoor"))
            {
                if (target.GetComponent<Rigidbody>().isKinematic == true)
                {
                    target.GetComponent<Rigidbody>().isKinematic = false;
                }
            }
            target.GetComponent<SlidingDoor>().isLocked = false;
            Destroy(gameObject);
        }
    }
}

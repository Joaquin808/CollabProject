using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverDoorKey : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Lever Cue")
        {
            target.GetComponent<SlidingDoor>().isLocked = false;
        }
    }
}

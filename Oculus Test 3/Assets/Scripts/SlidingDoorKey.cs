using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoorKey : MonoBehaviour
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
        if (other.gameObject.tag == "Hand")
        {
            target.GetComponent<SlidingDoor>().isLocked = false;
        }
    }
}

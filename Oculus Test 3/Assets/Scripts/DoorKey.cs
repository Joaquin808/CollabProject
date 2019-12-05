using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    public GameObject door, keycard, keypadLight;
    Renderer rend;
    public Material mat;

    void Start()
    {
        rend = keypadLight.GetComponent<Renderer>();
    }

    void Update()
    {
        if (!door.GetComponent<SlidingDoor>().isLocked)
        {
            rend.material = mat;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == keycard)
        {
            door.GetComponent<SlidingDoor>().isLocked = false;

           
            //Destroy(gameObject);
        }
    }
}

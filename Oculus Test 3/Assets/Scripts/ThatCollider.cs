using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThatCollider : MonoBehaviour
{
    public bool itIn;
    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Sphere")
        {
            itIn = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        itIn = false;
    }

}

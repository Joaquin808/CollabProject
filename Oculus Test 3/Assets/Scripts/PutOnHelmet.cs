using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutOnHelmet : MonoBehaviour
{
    public GameObject helmet;
    public bool isHelmetOn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   void OnTriggerEnter(Collider other)
    {
       if(other.gameObject == helmet)
        {
            isHelmetOn = true;
            Destroy(other.gameObject);
        }
    }
}

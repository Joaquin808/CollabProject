using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Locker_Collision_Script : MonoBehaviour
{
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Circuit")
        {
            Debug.Log("That seems to fit...");
        }
    }
}

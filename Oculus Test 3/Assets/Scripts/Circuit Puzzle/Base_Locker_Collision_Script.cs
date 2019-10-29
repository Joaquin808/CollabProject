using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Locker_Collision_Script : MonoBehaviour
{
    public GameObject panel;
    public string cubeName = "pCube10_powerpuzzle";
    Rigidbody rb;
    public static bool isTriggered;

    // Start is called before the first frame update
    void Start()
    {
        isTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "panel-locker")
        {
            Debug.Log("That seems to fit...");
            panel.transform.position = this.transform.position;
            panel.GetComponent<Rigidbody>().useGravity = false;
            isTriggered = true;
            GameObject.Find(cubeName).GetComponent<OVRGrabbable>().enabled = false;
            //Look into force release from the OVRGrabbable script
        }
    }
}

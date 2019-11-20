using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneLeavePlayer : MonoBehaviour
{

    void Start()
    {
        GameObject.Find("Dog").GetComponent<DogAi>().boneHeldPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<OVRGrabbable>().isGrabbed == false)
        {
            GameObject.Find("Dog").GetComponent<DogAi>().boneHeldPlayer = false;
            //GameObject.Find("Dog").GetComponent<DogAi>().boneHeld = false;
        }
        else if (this.GetComponent<OVRGrabbable>().isGrabbed)
        {
            GameObject.Find("Dog").GetComponent<DogAi>().boneHeldPlayer = true;
        }

        if (this.transform.position.z <= -2) {
            GameObject.Find("Dog").GetComponent<DogAi>().CurrentState = DogAi.DogState.GRAB;
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "GrabVolumeBig")
        {
            GameObject.Find("Dog").GetComponent<DogAi>().boneHeldPlayer = true;
            GameObject.Find("Dog").GetComponent<DogAi>().boneHeld = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "GrabVolumeBig")
        {
            GameObject.Find("Dog").GetComponent<DogAi>().boneHeldPlayer = false;
            GameObject.Find("Dog").GetComponent<DogAi>().boneHeld = true;
        }
    }*/

}

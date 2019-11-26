using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneLeavePlayer : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<OVRGrabbable>().isGrabbed == false)
        {
            GameObject.Find("Dog").GetComponent<DogAi>().boneHeldPlayer = false;
        }
    }

}

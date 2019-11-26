using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrenchObjective : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<OVRGrabbable>().isGrabbed == true)
        {
            Objectives ObjectiveScript = GameObject.Find("OVRPlayerController").GetComponent<Objectives>();
            if (ObjectiveScript.ObjectiveNumber == 2)
            {
                ObjectiveScript.SetNextObjective();
            }
        }
    }
}

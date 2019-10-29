using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class panel_grabbable : OVRGrabbable 
{
    private static bool isTriggered;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
        isTriggered = Base_Locker_Collision_Script.isTriggered;
            if (isTriggered == true)
            {
                grabbedBy.ForceRelease(this);
            }
        }
}



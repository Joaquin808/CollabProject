using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICore : MonoBehaviour
{
    bool TalkedToAIFirstTime = false;
    SoundEffects SFXScript;
    Objectives ObjScript;

    // Start is called before the first frame update
    void Start()
    {
        SFXScript = GameObject.Find("OVRPlayerController").GetComponent<SoundEffects>();
        ObjScript = GameObject.Find("OVRPlayerController").GetComponent<Objectives>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (TalkedToAIFirstTime == false && ObjScript.ObjectiveNumber == 6)
            {
                SFXScript.genAudio.Play(SFXScript.genSounds[22]);
                ObjScript.SetNextObjective();
            }
        }
    }
}

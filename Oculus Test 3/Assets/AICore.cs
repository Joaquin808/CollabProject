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

            if (ObjScript.ObjectiveNumber == 2)
            {
                SFXScript.genAudio.Stop();
                SFXScript.genAudio.clip = SFXScript.genSounds[22];
                SFXScript.genAudio.Play();
            }

            if (ObjScript.ObjectiveNumber == 3)
            {
                SFXScript.genAudio.Stop();
                SFXScript.genAudio.clip = SFXScript.genSounds[28];
                SFXScript.genAudio.Play();
            }

            if (ObjScript.ObjectiveNumber == 4)
            {
                SFXScript.genAudio.Stop();
                SFXScript.genAudio.clip = SFXScript.genSounds[26];
                SFXScript.genAudio.Play();
            }

            if (ObjScript.ObjectiveNumber == 5)
            {
                SFXScript.genAudio.Stop();
                SFXScript.genAudio.clip = SFXScript.genSounds[27];
                SFXScript.genAudio.Play();
            }
        }
    }
}

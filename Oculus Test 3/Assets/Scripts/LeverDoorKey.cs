using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverDoorKey : MonoBehaviour
{
    public GameObject target;
    public GameObject lever;
    SoundEffects soundFX;
    Objectives objectives;

    void Start()
    {
        soundFX = GameObject.Find("SoundEffectsManager").GetComponent<SoundEffects>();
        objectives = GameObject.Find("OVRPlayerController").GetComponent<Objectives>();
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Lever Cue")
        {
            target.GetComponent<SlidingDoor>().isLocked = false;
            lever.GetComponent<Rigidbody>().isKinematic = true;
            objectives.SetNextObjective();
            if (soundFX.genAudio.clip != soundFX.genSounds[15])
            {
                soundFX.genAudio.Stop();
                soundFX.genAudio.clip = soundFX.genSounds[15];
                soundFX.genAudio.Play();
            }
            else
            {
                soundFX.genAudio.Play();
            }
        }
    }
}

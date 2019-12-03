using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverDoorKey : MonoBehaviour
{
    public GameObject target;
    public GameObject lever;
    public SoundEffects soundFX;


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Lever Cue")
        {
            target.GetComponent<SlidingDoor>().isLocked = false;
            lever.GetComponent<Rigidbody>().isKinematic = true;
            //GameObject.Find("OVRPlayerController").GetComponent<Objectives>().SetNextObjective();
            if (soundFX.genAudio.clip != soundFX.genSounds[15])
            {
                soundFX.genAudio.Stop();
                soundFX.genAudio.clip = soundFX.genSounds[15];
                soundFX.genAudio.Play();
            }

        }
    }
}

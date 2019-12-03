using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objectives : MonoBehaviour
{
        public string[] ObjectivesList = {"Find a key to get out of the room" /*0, done*/, "Fix the Power Station"/*1, done*/,
        "Talk to the AI"/*2, done*/, "Fix the Water Station (Dome)"/*3, done*/, "Fix Air Filtration (Dome)"/*4, done*/,
        "Fix the Temperature Station (House)"/*5, done*/, "Listen to Grandpa's message"/*6, need to do*/, "Escape the Dome"/*7, need to do*/};

    public Text ObjectiveText;
    public int ObjectiveNumber = 0;
    SoundEffects SFXScript;

    // Start is called before the first frame update
    void Start()
    {
        ObjectiveText.text = ObjectivesList[ObjectiveNumber];
        SFXScript = GameObject.Find("OVRPlayerController").GetComponent<SoundEffects>();
    }

    public void SetNextObjective()
    {
        ObjectiveNumber++;
        ObjectiveText.text = ObjectivesList[ObjectiveNumber];

        // will play ding sound to alert player that the objective has been completed
        SFXScript.genAudio.Stop();
        SFXScript.genAudio.clip = SFXScript.genSounds[3];
        SFXScript.genAudio.Play();

        // will play corresponding AI Core message after an objective has been completed
        if (ObjectiveNumber == 6)
        {
            SFXScript.genAudio.Stop();
            SFXScript.genAudio.clip = SFXScript.genSounds[23];
            SFXScript.genAudio.Play();
        }

        if (ObjectiveNumber == 4)
        {
            SFXScript.genAudio.Stop();
            SFXScript.genAudio.clip = SFXScript.genSounds[24];
            SFXScript.genAudio.Play();
        }

        if (ObjectiveNumber == 5)
        {
            SFXScript.genAudio.Stop();
            SFXScript.genAudio.clip = SFXScript.genSounds[21];
            SFXScript.genAudio.Play();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (ObjectiveNumber == 0 && other.gameObject.name == "FirstObjective")
        {
            SetNextObjective();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{

    public AudioSource dialogueAudio;
    public AudioClip[] dialogueSounds;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void findAmbientAudio()
    {
        if (dialogueAudio.clip != dialogueSounds[0])
        {
            soundFXD.dialogueAudio.Stop();
            soundFXD.dialogueAudio.clip = soundFX.genSounds[15];
            soundFXD.dialogueAudio.Play();
        }
    }
}
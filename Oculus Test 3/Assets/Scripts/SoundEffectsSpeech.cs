using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsSpeech : MonoBehaviour
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
            dialogueAudio.Stop();
            dialogueAudio.clip = dialogueSounds[0];
            dialogueAudio.Play();
        }
    }
}
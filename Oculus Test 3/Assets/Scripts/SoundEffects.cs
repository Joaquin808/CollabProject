﻿    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{

    public AudioSource genAudio;
    public AudioClip[] genSounds;


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
        if (genAudio.clip != genSounds[0])
        {

        }
    }
}

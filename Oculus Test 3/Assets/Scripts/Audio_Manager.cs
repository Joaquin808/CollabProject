using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    public AudioClip[] music;
    public AudioSource manager;

    // Update is called once per frame

    void Update()
    {
        if(manager.isPlaying == false)
        {
            manager.clip = music[0];
            manager.Play(0);
        }
    }
}

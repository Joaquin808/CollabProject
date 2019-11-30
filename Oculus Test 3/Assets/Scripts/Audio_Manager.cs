using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    public AudioClip[] music;
    public AudioSource manager;
    int track = -1;

    // Update is called once per frame

    void Update()
    {
        if(manager.isPlaying == false)
        {
            if (track > music.Length)
            {
                track = -1;
                manager.clip = music[track];
                manager.Play(0);
            }
            else
            {
                track++;
                manager.clip = music[track];
                manager.Play(0);
            }


        }
    }
}

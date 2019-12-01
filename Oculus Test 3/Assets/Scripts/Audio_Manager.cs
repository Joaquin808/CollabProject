using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    public AudioClip[] music;
    public AudioSource manager;
    int track = 0;

    // Update is called once per frame

    void Update()
    {
        if(manager.isPlaying == false)
        {
            if (track <= music.Length)
            {
                manager.clip = music[track];
                track++;
                manager.Play(0);

            }
            else if (track > music.Length) 
            {
                track = 0;
                manager.clip = music[track];
                manager.Play(0);
            }
        }
    }
}

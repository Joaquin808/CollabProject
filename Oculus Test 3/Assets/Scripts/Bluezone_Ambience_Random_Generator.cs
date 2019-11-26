using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bluezone_Ambience_Random_Generator : MonoBehaviour
{
    public AudioClip[] bluezoneArray;
    public AudioSource bluezoneAmbience;
    public AudioSource bluezoneRandom;
    public AudioSource bluezoneRandom2;
    public float ApitchMin, ApitchMax, AvolumeMin, AvolumeMax;
    public float RpitchMin2, RpitchMax2, RvolumeMin2, RvolumeMax2;
    public float R2pitchMin3, R2pitchMax3, R2volumeMin3, R2volumeMax3;

    private int bluezoneIndex;

    void Start()
    {
        PlayRoundRobin();
        PlayRandom();
        
    }

    void Update()
    {
        //PlayRandom();
        //PlayRandom2();
        if (bluezoneRandom.isPlaying == false)
        {
            PlayRandom2();
        }
        else if (bluezoneRandom2.isPlaying == false)
        {
            PlayRandom();
        }
    }

    void PlayRoundRobin()
    {
        bluezoneAmbience.volume = Random.Range(AvolumeMin, AvolumeMax);
        if (bluezoneIndex < bluezoneArray.Length)
        {
            bluezoneAmbience.PlayOneShot(bluezoneArray[bluezoneIndex]);
            bluezoneIndex++;
        }
        else
        {
            bluezoneIndex = 0;
            bluezoneAmbience.PlayOneShot(bluezoneArray[bluezoneIndex]);
            bluezoneIndex++;
        }
    }

    void PlayRandom()
    {
        bluezoneRandom.volume = Random.Range(RvolumeMin2, RvolumeMax2);
        bluezoneIndex = Random.Range(1, 1);  //*Original* bluezoneIndex = Random.Range(0, bluezoneArray.Length);
        bluezoneRandom.PlayOneShot(bluezoneArray[bluezoneIndex]);
        if (bluezoneRandom.isPlaying == false)
        {
            PlayRandom2();
        }
    }

    void PlayRandom2()
    {
        bluezoneRandom2.volume = Random.Range(R2volumeMin3, R2volumeMax3);
        //bluezoneIndex = RepeatCheck(bluezoneIndex, bluezoneArray.Length);
        bluezoneIndex = Random.Range(2, 2);
        bluezoneRandom2.PlayOneShot(bluezoneArray[bluezoneIndex]);
        if (bluezoneRandom2.isPlaying == false)
        {
            PlayRandom();
        }
    }

    int RepeatCheck(int previousIndex, int range)
    {
        int index = Random.Range(0, range);

        while (index == previousIndex)
        {
            index = Random.Range(0, range);
        }

        return index;
    }
}

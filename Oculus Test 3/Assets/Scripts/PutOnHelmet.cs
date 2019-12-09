using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PutOnHelmet : MonoBehaviour
{
    public GameObject helmet;
    public bool isHelmetOn;
    public GameObject helmetPP;
    SoundEffects soundFX;

    // Start is called before the first frame update
    void Start()
    {
        helmetPP = GameObject.Find("SpaceHelmet_PP");
        soundFX = helmetPP.GetComponent<SoundEffects>();
    }

   void OnTriggerEnter(Collider other)
    {
       if(other.gameObject == helmet)
        {
            isHelmetOn = true;
            helmetPP.GetComponent<PostProcessLayer>().enabled = true;
            if (soundFX.genAudio.clip != soundFX.genSounds[1])
            {
                soundFX.genAudio.Stop();
                soundFX.genAudio.clip = soundFX.genSounds[1];
                soundFX.genAudio.Play();

            }            
            Destroy(other.gameObject);
        }
    }
}

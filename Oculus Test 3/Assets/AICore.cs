using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICore : MonoBehaviour
{
    bool TalkedToAIFirstTime = false;
    SoundEffects SFXScript;

    // Start is called before the first frame update
    void Start()
    {
        SFXScript = GameObject.Find("OVRPlayerController").GetComponent<SoundEffects>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (TalkedToAIFirstTime == false)
            {
                //SFXScript.genAudio.Play(SFXScript.genSounds[22]);
            }
        }
    }
}

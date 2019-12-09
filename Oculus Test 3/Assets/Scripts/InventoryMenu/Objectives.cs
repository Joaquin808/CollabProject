using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objectives : MonoBehaviour
{
    public string[] ObjectivesList;

    public Text ObjectiveText;
    public int ObjectiveNumber = 0;
    SoundEffects SFXScript;
    SoundEffectsSpeech SoundEffectsDialogue;

    // Start is called before the first frame update
    void Start()
    {
        ObjectiveText.text = ObjectivesList[ObjectiveNumber];
        SFXScript = GameObject.Find("SoundEffectsManager").GetComponent<SoundEffects>();
        SoundEffectsDialogue = GameObject.Find("DialogueSoundManager").GetComponent<SoundEffectsSpeech>();
    }

    public void SetNextObjective()
    {
        ObjectiveNumber++;
        ObjectiveText.text = ObjectivesList[ObjectiveNumber];

        // will play ding sound to alert player that the objective has been completed
        SFXScript.genAudio.Stop();
        SFXScript.genAudio.clip = SFXScript.genSounds[3];
        SFXScript.genAudio.Play();

        // AI Message after power is restored
        if (ObjectiveNumber == 2)
        {
            SoundEffectsDialogue.dialogueAudio.Stop();
            SoundEffectsDialogue.dialogueAudio.clip = SoundEffectsDialogue.dialogueSounds[0];
            SoundEffectsDialogue.dialogueAudio.Play();
            print(2);
        }

        // AI message after temperature is restored
        if (ObjectiveNumber == 3)
        {
            SoundEffectsDialogue.dialogueAudio.Stop();
            SoundEffectsDialogue.dialogueAudio.clip = SoundEffectsDialogue.dialogueSounds[1];
            SoundEffectsDialogue.dialogueAudio.Play();
            print(3);
        }

        // AI message after water is restored
        if (ObjectiveNumber == 4)
        {
            SoundEffectsDialogue.dialogueAudio.Stop();
            SoundEffectsDialogue.dialogueAudio.clip = SoundEffectsDialogue.dialogueSounds[2];
            SoundEffectsDialogue.dialogueAudio.Play();
            print(4);
        }

        //AI Message after air is restored
        if (ObjectiveNumber == 5)
        {
            SoundEffectsDialogue.dialogueAudio.Stop();
            SoundEffectsDialogue.dialogueAudio.clip = SoundEffectsDialogue.dialogueSounds[3];
            SoundEffectsDialogue.dialogueAudio.Play();
            print(5);
        }

        //AI Message after hearing Grandpa's message
        if (ObjectiveNumber == 6)
        {
            SoundEffectsDialogue.dialogueAudio.Stop();
            SoundEffectsDialogue.dialogueAudio.clip = SoundEffectsDialogue.dialogueSounds[4];
            SoundEffectsDialogue.dialogueAudio.Play();
            print(6);
        }
    }
    
}

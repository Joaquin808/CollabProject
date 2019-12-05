using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectVisibility : MonoBehaviour
{
    List<string> collisionList = new List<string>();
    public bool isVisible = false;
    Renderer rend;
    public string String;
    private GameObject destroyedPipe;
    public int pipesFixed = 0;
    public Alerts AlertSystem;
    int TypeOfAlert = 1;
    public Pickup InventoryItemRef;
    bool SolvedFirstTime = false;
    public SoundEffects soundFX;
    Objectives ObjectiveScript;
    PipeCheck PipeCheck;

    void Start()
    {
        rend = GetComponent<Renderer>();
        ObjectiveScript = GameObject.Find("OVRPlayerController").GetComponent<Objectives>();
        PipeCheck = GameObject.Find("Water Filter").GetComponent<PipeCheck>();
    }

    void Update()
    {
        rend.enabled = isVisible;

    }


    void PrintList()
    {
        for (int i = 0; i < collisionList.Count; i++)
        {
            print(collisionList[i]);
        }
    }

    void OnTriggerEnter(Collider collision)
    {

        if (ObjectiveScript.ObjectiveNumber == 3 || SolvedFirstTime)
        {
            if (!collisionList.Contains(collision.gameObject.name))
            {
                collisionList.Add(collision.gameObject.name);
            }

            if (collisionList.Contains(String) && collisionList.Contains("Wrench"))
            {
                isVisible = true;
                collisionList.Remove(String);
                collisionList.Remove("Wrench");
                destroyedPipe = GameObject.Find(String);
                destroyedPipe.GetComponent<Renderer>().enabled = false;
                destroyedPipe.GetComponent<RigidBody>().enabled = false;
                //Destroy(destroyedPipe);
                PipeCheck.pipesFixed++;

                if (PipeCheck.pipesFixed == 7)
                {
                    AlertSystem.DeactivateAlert(TypeOfAlert);
                    SolvedFirstTime = true;
                    if (ObjectiveScript.ObjectiveNumber == 3)
                    {
                        ObjectiveScript.SetNextObjective();
                    }
                }

                if (soundFX.genAudio.clip != soundFX.genSounds[15])
                {
                    soundFX.genAudio.Stop();
                    soundFX.genAudio.clip = soundFX.genSounds[15];
                    soundFX.genAudio.Play();
                }
            }
        }

    }



    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == String)
        {
            collisionList.Remove(String);

        }

        if (collision.gameObject.tag == "Wrench")
        {
            collisionList.Remove("Wrench");
        }

    }

}
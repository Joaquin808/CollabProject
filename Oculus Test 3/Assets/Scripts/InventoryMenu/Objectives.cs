using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objectives : MonoBehaviour
{
    string[] ObjectivesList = {"Find a key to get out of the room", "Find the Power Switch and activate it", "Find the wrench", "Use the wrench to get access to the Power Station",
        "Complete the puzzle of the Power Station", "Exit the Bunker and find an entrane to the House", "Talk to the AI", "Fix AC Station (House)", "Fix the Water Station (Dome)",
        "Find a way to access the locked room (House)", "Pick up the Temperature Needle", "Fix the Temperature Station (House)", "Find a way to open the main locker (Bunker)",
        "Pick up the key and get access to Grandpa's room", "Use the Radio", "Find a way to open Grandpa's safe", "Listen to Grandpa's message",
        "Find all the components for the Suit", "Escape the dome", "Destoy the AI core"};

    public Text ObjectiveText;
    public int ObjectiveNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        ObjectiveText.text = ObjectivesList[ObjectiveNumber];
    }

    public void SetNextObjective()
    {
        ObjectiveNumber++;
        ObjectiveText.text = ObjectivesList[ObjectiveNumber];
    }

    void OnTriggerEnter(Collider other)
    {
        if (ObjectiveNumber == 0 && other.gameObject.name == "FirstObjective")
        {
            SetNextObjective();
        }
    }
}

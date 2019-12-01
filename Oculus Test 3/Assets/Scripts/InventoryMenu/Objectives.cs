using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objectives : MonoBehaviour
{
    public string[] ObjectivesList = {"Find a key to get out of the room" /*0, done*/, "Find the Power Switch and activate it"/*1, done*/, "Find the wrench"/*2, done*/,
        "Use the wrench to get access to the Power Station"/*3, done*/, "Fix the Power Station"/*4, done*/, "Exit the Bunker and find an entrance to the House"/*5 done*/,
        "Talk to the AI"/*6, done*/,  "Fix the Water Station (Dome)"/*7, done*/, "Fix Air Filtration (Dome)"/*8, done*/, "Find a way to access the locked room (House)"/*9, need to fix pressure plate*/,
        "Pick up the Temperature Needle"/*10, done*/, "Fix the Temperature Station (House)"/*11, done*/, "Find a way to open the main locker (Bunker)"/*12, need to do*/,
        "Pick up the key and get access to Grandpa's room"/*13, need to do*/, "Use the Radio"/*14, need to do*/, "Find a way to open Grandpa's safe"/*15, Need to do*/,
        "Listen to Grandpa's message"/*16, need to do*/,"Find all the components for the Suit"/*17, need to do*/, "Destroy AI Core"/*18, need to do*/, "Escape the Dome"/*19, need to do*/};

    public Text ObjectiveText;
    public int ObjectiveNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        ObjectiveText.text = ObjectivesList[ObjectiveNumber];
    }

    void Update()
    {
        if (ObjectiveNumber == 6)
        {
            SetNextObjective();
        }
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

        if (ObjectiveNumber == 5 && other.gameObject.name == "EnterHouseObjective")
        {
            SetNextObjective();
        }

        if (ObjectiveNumber == 9 && other.gameObject.name == "GetIntoLockedRoomObjective")
        {
            SetNextObjective();
        }
    }
}

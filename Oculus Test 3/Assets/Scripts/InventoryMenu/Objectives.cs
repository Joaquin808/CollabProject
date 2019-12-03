using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objectives : MonoBehaviour
{
        public string[] ObjectivesList = {"Find a key to get out of the room" /*0, done*/, "Fix the Power Station"/*1, done*/,
        "Talk to the AI"/*2, done*/, "Fix the Water Station (Dome)"/*3, done*/, "Fix Air Filtration (Dome)"/*4, done*/,
        "Fix the Temperature Station (House)"/*5, done*/, "Listen to Grandpa's message"/*6, need to do*/, "Escape the Dome"/*7, need to do*/};

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

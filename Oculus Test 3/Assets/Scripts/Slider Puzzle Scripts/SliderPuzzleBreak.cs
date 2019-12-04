using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPuzzleBreak : MonoBehaviour
{
    public int AlertType = 3;
    public int puzzleCompleteCheck = 0;
    public bool SolvedFirstTime = false;

    public Alerts alerts; //call to alerts script
    public GameObject needle, needle2;
    Renderer needle1Rend, needle2Rend;

    //bool broken = true;
    //public GameObject player;

    //public bool powerBroken = true;

    void Start()
    {

    }

    void Update()
    {
        //powerBroken = GameObject.Find("Power Puzzle Pieces").GetComponent<PowerOn>().isBroken;
        //if (broken)
        //{
            //OnBreak();
           
                
        //}
    }

    //Function used to break temperature puzzle
    void OnBreak()
    {
        alerts.ActivateAlert("Temperature critical!", AlertType);
        //needle2Rend.enabled = true;
        //broken = false;
    }

    //Function to fix temperature puzzle
    void OnFix()
    {
        Destroy(needle2.gameObject);
        needle1Rend.enabled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == needle2)
        {
            OnFix();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPuzzleBreak : MonoBehaviour
{
    public int AlertType = 3;
    public int puzzleCompleteCheck = 0;
    public bool SolvedFirstTime = false;

    public Alerts alerts; //call to alerts script
    Objectives objectives;
    public GameObject Player;

    //bool broken = true;
    //public GameObject player;

    //public bool powerBroken = true;

    void Start()
    {
        objectives = Player.GetComponent<Objectives>();
    }

    void Update()
    {
        if (puzzleCompleteCheck == 3)
        {
            objectives.SetNextObjective();
        }
    }

}

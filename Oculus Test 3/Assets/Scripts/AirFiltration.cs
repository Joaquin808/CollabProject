using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirFiltration : MonoBehaviour
{
    public GameObject dial, fanOne, fanTwo, fanThree, solution;
    public Alerts AlertSystem;
    Rigidbody rb;
    AudioSource wind;
    //float solutionOne, solutionTwo, dialPointed, timer, dialZ;
    float timer;
    //bool inSpot;
    //bool SolvedFirstTime = false;
    public bool solved;
    bool fanOneIn, fanTwoIn, fanThreeIn;
    RealFanScript rfscrp;
    ThatCollider tcscrp;
    Objectives ObjectiveScript;



    // Start is called before the first frame update
    void Start()
    {
        rb = dial.GetComponent<Rigidbody>();
        tcscrp = solution.GetComponent<ThatCollider>();
        //RandomSolution();
        wind = gameObject.GetComponent<AudioSource>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //dialPointed = rb.transform.rotation.eulerAngles.x;
        //dialZ = rb.transform.rotation.eulerAngles.z;
        //Debug.Log(dialZ);
        //Debug.Log("The dial is pointed at " + dialZ);

        FansIn();
        Debug.Log("Fan1: " + fanOneIn);
        Debug.Log("Fan2: " + fanTwoIn);
        Debug.Log("Fan3: " + fanThreeIn);
        if (fanOneIn && fanTwoIn && fanThreeIn)
        {
            ObjectiveScript = GameObject.Find("OVRPlayerController").GetComponent<Objectives>();
            if (ObjectiveScript.ObjectiveNumber == 4)
            {
                //Debug.Log(tcscrp.itIn);
                if (tcscrp.itIn)
                {
                    SolutionFinder();
                }
            }
        }

    }

    //Sets each bool to each fan's fanIn bool, asks if all fans are in
    void FansIn()
    {
        rfscrp = fanOne.GetComponent<RealFanScript>();
        fanOneIn = rfscrp.fanIn;
        rfscrp = fanTwo.GetComponent<RealFanScript>();
        fanTwoIn = rfscrp.fanIn;
        rfscrp = fanThree.GetComponent<RealFanScript>();
        fanThreeIn = rfscrp.fanIn;
    }

    //creates a random solution for the air filtration puzzle
    //void RandomSolution()
    //{
    //    int x = Random.Range(1, 13);
    //    solutionOne = x * 30;
    //    solutionTwo = solutionOne + 30;
    //    if (solutionOne == 360f && solutionTwo == 390f)
    //    {
    //        solutionOne = 30f;
    //        solutionTwo = 60f;
    //    }
    //    FixSolutions();
    //}

    //void CheckIfSolved()
    //{
        

        //Checks if the z is in the 1 and 4 quadrants
        //if (80f < dialZ && dialZ < 100f)
        ////{
        //    if (30f < dialPointed && dialPointed < 60f)
        //    {
        //        SolutionFinder();
        //    }

        // }
        //Checks if the z is in the 2 and 3 quadrants
        //if (260f < dialZ && dialZ < 280f)
        //{

        //    if (solutionTwo < dialPointed && dialPointed < solutionOne)
        //    {
        //        SolutionFinder();
        //    }
        //}

    //}

    //Fixs the solutions to work within unity, hopefully
    //void FixSolutions()
    //{
    //    if (solutionOne == 90 && solutionTwo == 120)
    //    {
    //        solutionOne = 90;
    //        solutionTwo = 60;
    //    }
    //    if (solutionOne == 120)
    //    {
    //        solutionOne = 60;
    //        solutionTwo = 30;
    //    }
    //    if (solutionOne == 150)
    //    {
    //        solutionOne = 30;
    //        solutionTwo = 0;
    //    }
    //    if (solutionOne == 180)
    //    {
    //        solutionOne = 360;
    //        solutionTwo = 330;
    //    }
    //    if (solutionOne == 210)
    //    {
    //        solutionOne = 330;
    //        solutionTwo = 300;
    //    }
    //    if (solutionOne == 240)
    //    {
    //        solutionOne = 300;
    //        solutionTwo = 270;
    //    }
    //}

    void SolutionFinder()
    {
        Debug.Log("There is wind not");
        if (timer == 0)
        {
            if (!wind.isPlaying)
            {
                wind.Play(0);
            }
        }
        timer += Time.deltaTime;
        if (timer >= 5)
        {
            rb.freezeRotation = true;
            solved = true;
            AlertSystem.DeactivateAlert(2);
            //if (!SolvedFirstTime)
            //{
            //    SolvedFirstTime = true;
            //    Objectives ObjectiveScript = GameObject.Find("OVRPlayerController").GetComponent<Objectives>();
            //    ObjectiveScript.SetNextObjective();
            //}
        }
        Debug.Log("Seconds: " + timer);
    }


    //void OnBreak()
    //{
    //    AlertSystem.ActivateAlert("Air quality decreasing", 2);
    //    RandomSolution();
    //    rb.freezeRotation = false;
    //    wind.Stop();
    //    rb.transform.eulerAngles = new Vector3(0, 0, 0);
    //    solved = false;
    //}
}

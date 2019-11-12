using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirFiltration : MonoBehaviour
{
    public GameObject dial, airFilt;
    Rigidbody rb;
    float solutionOne, solutionTwo, dialPointed, timer, dialZ;
    AudioSource wind;
    bool inSpot;
    public bool solved;
    //int seconds;
    public Alerts AlertSystem;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = dial.GetComponent<Rigidbody>();
        RandomSolution();
        wind = airFilt.GetComponent<AudioSource>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        dialPointed = rb.transform.rotation.eulerAngles.x;
        dialZ = rb.transform.rotation.eulerAngles.z;
        //Debug.Log("Solution One: " + solutionOne);
        //Debug.Log("Solution Two: " + solutionTwo);
        //Debug.Log("Dial: " + dialPointed);
        //Debug.Log("Dialz: " + dialZ);
        //Debug.Log(solved);
        CheckIfSolved();
        
    }

    //creates a random solution for the air filtration puzzle
    void RandomSolution()
    {
        int x = Random.Range(1, 13);
        solutionOne = x * 30;
        solutionTwo = solutionOne + 30;
        if (solutionOne == 360f && solutionTwo == 390f)
        {
            solutionOne = 30f;
            solutionTwo = 60f;
        }
        FixSolutions();
    }

    void CheckIfSolved()
    {
        
       
        //solutionOne < dialPointed && dialPointed < solutionTwo is what I used to begin with
        if (80f < dialZ && dialZ < 100f)
        {
            if (solutionTwo < dialPointed && dialPointed < solutionOne)
            {
                SolutionFinder();
            }
            /*
            else if (timer < 5)
            {
                timer = 0;
                wind.Stop();
            }
            */
        }
        if (260f < dialZ && dialZ < 280f)
        {
            
            if (solutionOne < dialPointed && dialPointed < solutionTwo)
            {
                SolutionFinder();
            }
        }

    }

    //Fixs the solutions to work within unity, hopefully
    void FixSolutions()
    {
        if (solutionOne == 90 && solutionTwo == 120)
        {
            solutionOne = 90;
            solutionTwo = 60;
        }
        if (solutionOne == 120)
        {
            solutionOne = 60;
            solutionTwo = 30;
        }
        if (solutionOne == 150)
        {
            solutionOne = 30;
            solutionTwo = 0;
        }
        if (solutionOne == 180)
        {
            solutionOne = 360;
            solutionTwo = 330;
        }
        if (solutionOne == 210)
        {
            solutionOne = 330;
            solutionTwo = 300;
        }
        if (solutionOne == 240)
        {
            solutionOne = 300;
            solutionTwo = 270;
        }
    }

    void SolutionFinder()
    {
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
        }
        Debug.Log("Seconds: " +timer);
    }
      

    void OnBreak()
    {
        AlertSystem.ActivateAlert("Air quality decreasing", 2);
        RandomSolution();
        rb.freezeRotation = false;
        wind.Stop();
        rb.transform.eulerAngles = new Vector3(0, 0, 0);
        solved = false;
    }
}
/*
           if (dialPointed == .5 || dialPointed == -.5)
           {
               if (timer == 0)
               {
                   wind.Play(0);
               }
               timer += Time.deltaTime;
               if (timer >= 5)
               {
                   rb.freezeRotation = true;
                   solved = true;
               }
               Debug.Log("Wind is working");
               Debug.Log(timer);
           }
           else if (timer < 5)
           {
               timer = 0;
               wind.Stop();
           }
       }
       */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirFiltration : MonoBehaviour
{
    public GameObject dial, airFilt;
    Rigidbody rb;
    float solutionOne, solutionTwo, dialPointed, timer;
    AudioSource wind;
    public bool solved;
    public Alerts AlertSystem;
    //int seconds;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = dial.GetComponent<Rigidbody>();
        RandomSolution();
        wind = airFilt.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        dialPointed = rb.transform.eulerAngles.x;
        CheckIfSolved();
    }

    void RandomSolution()
    {
        int x = Random.Range(1, 13);
        solutionOne = (x / 12) * 360;
        solutionTwo = solutionOne + 30;
        if (solutionOne == 360f && solutionTwo == 390f)
        {
            solutionOne = 0f;
            solutionTwo = 30f;
        }
    }

    void CheckIfSolved()
    {
        if (solutionOne < dialPointed && dialPointed < solutionTwo)
        {
            wind.Play(0);
            timer = Time.deltaTime;
            //seconds = Convert.ToInt32(timer % 60);
            if (timer >= 5)
            {
                rb.freezeRotation = true;
                solved = true;
            }
        }
        else if (timer < 5)
        {
            timer = 0;
            wind.Stop();
        }
    }

    void OnBreak()
    {
        AlertSystem.ActivateAlert("Thing you want the alert to say", 2);
        RandomSolution();
        rb.freezeRotation = false;
        wind.Stop();
        rb.transform.eulerAngles = new Vector3(0, 0, 0);
        solved = false;
    }
}

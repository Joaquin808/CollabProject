using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirFiltration : MonoBehaviour
{
    public GameObject dial, fanOne, fanTwo, fanThree, solution;
    public Alerts AlertSystem;
    Rigidbody rb;
    AudioSource wind;
    float timer = 0;
    public bool solved;
    bool fanOneIn, fanTwoIn, fanThreeIn;
    RealFanScript rfscrp1;
    RealFanScript rfscrp2;
    RealFanScript rfscrp3;
    ThatCollider tcscrp;
    Objectives ObjectiveScript;
     public GameObject[] FanList;
    float rotationSpeed = 1;
    float fanX = 107;

    // Start is called before the first frame update
    void Start()
    {
        rb = dial.GetComponent<Rigidbody>();
        tcscrp = solution.GetComponent<ThatCollider>();
        wind = gameObject.GetComponent<AudioSource>();
        ObjectiveScript = GameObject.Find("OVRPlayerController").GetComponent<Objectives>();
        rfscrp1 = fanOne.GetComponent<RealFanScript>();
        rfscrp2 = fanTwo.GetComponent<RealFanScript>();
        rfscrp3 = fanThree.GetComponent<RealFanScript>();
    }

    // Update is called once per frame
    void Update()
    {

        //Sets each bool to each fan's fanIn bool, asks if all fans are in
        fanOneIn = rfscrp1.fanIn;
        fanTwoIn = rfscrp2.fanIn;
        fanThreeIn = rfscrp3.fanIn;

        if (fanOneIn && fanTwoIn && fanThreeIn && ObjectiveScript.ObjectiveNumber == 4 && tcscrp.itIn)
        {
            SolutionFinder();
        }else
        {
            wind.Stop();
        }

        if(solved)
        {
            for (int i = 0; i < 10; i++)
            {
                fanX = fanX + (10 * rotationSpeed);
                FanList[i].gameObject.transform.Rotate(new Vector3(fanX, 0f, 0f));
            }
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

        for (int i = 0; i < 10; i++)
        {
            fanX = fanX + rotationSpeed;
            FanList[i].gameObject.transform.Rotate(new Vector3(fanX, 0f, 0f));
        }

        if (timer >= 2)
        {
            rb.freezeRotation = true;
            solved = true;
            AlertSystem.DeactivateAlert(2);
            ObjectiveScript.SetNextObjective();
        }
    }

}

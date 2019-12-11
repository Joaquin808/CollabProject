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
    bool fanOneIn, fanTwoIn, fanThreeIn, canSolve;

    int fans = 0;
    bool fan1 = false, fan2 = false, fan3 = false;

    RealFanScript rfscrp1;
    RealFanScript rfscrp2;
    RealFanScript rfscrp3;
    ThatCollider tcscrp;
    Objectives ObjectiveScript;
    public GameObject[] FanList;
    public GameObject grabbable;
    Rigidbody rbGrab;
    public GameObject middle;
    Rigidbody rbMid;
    float rotationSpeed = 0;
    float fanX = 107;

    // Start is called before the first frame update
    void Start()
    {
        rb = dial.GetComponent<Rigidbody>();
        rbGrab = grabbable.GetComponent<Rigidbody>();
        rbMid = grabbable.GetComponent<Rigidbody>();
        tcscrp = solution.GetComponent<ThatCollider>();
        wind = gameObject.GetComponent<AudioSource>();
        ObjectiveScript = GameObject.Find("OVRPlayerController").GetComponent<Objectives>();
        rfscrp1 = fanOne.GetComponent<RealFanScript>();
        rfscrp2 = fanTwo.GetComponent<RealFanScript>();
        rfscrp3 = fanThree.GetComponent<RealFanScript>();
        canSolve = false;
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
            if (!wind.isPlaying)
            {
                wind.Play(0);
            }
            if (!solved)
            {
                canSolve = true;
            }
        }

        timer += Time.deltaTime;

        for (int i = 0; i <= 8; i++)
        {
            FanList[i].gameObject.transform.Rotate(fanX * Time.deltaTime * rotationSpeed, 0f, 0f, Space.Self);
        }

        if (fans == 1)
        {
            rotationSpeed = 2;
        }
        else if (fans == 2)
        {
            rotationSpeed = 4;
        }
        else if (fans == 3)
        {
            rotationSpeed = 6;

        }

        if (fanOneIn && fan1 == false)
        {
            fans++;
            fan1 = true;
        }

        if (fanTwoIn && fan2 == false)
        {
            fans++;
            fan2 = true;
        }

        if (fanThreeIn && fan3 == false)
        {
            fans++;
            fan3 = true;
        }

        if (canSolve == true)
        {
            rb.freezeRotation = true;
            rb.isKinematic = true;
            rb.detectCollisions = false;
            rb.useGravity = false;
            rb.velocity = new Vector3(0, 0, 0);
            AlertSystem.DeactivateAlert(2);
            ObjectiveScript.SetNextObjective();
            solved = true;
            canSolve = false;
            rotationSpeed = 10;
        }

    }

}

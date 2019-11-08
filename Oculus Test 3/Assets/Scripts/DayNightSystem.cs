using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//skybox updater
//REQUIRES 7 MATERIALS && 1 GameObject IN SCENE

public class DayNightSystem : MonoBehaviour
{
    //Time
    public float currentTime = 0f;          //current currentTime
    public float dayLength = 1200f;         //DayLength = 20 minutes

    //Skybox References
    public Material skyOne;					//skybox 1
    public Material skyTwo;					//skybox 2
    public Material skyThree;				//skybox 3
    public Material skyFour;				//skybox 4
    public Material skyFive;                //skybox 5
    public Material skySix;                 //skybox 6
    public Material skySeven;               //skybox 7

    //Puzzle Triggers
    public bool powerDone = false;
    public bool pressureDone = false;
    public bool tempDone = false;
    public bool waterDone = false;
    public bool airDone = false;
    public bool radioDone = false;



    void Update()
    {

        /*
            //Puzzle Completion Based Time Transitions
            //MORE COMPLEX TIME CHECKS (MULTI Completion per stage) to prevent time going in reverse
            if (powerDone) {
                
            } else if (pressureDone) {
                if (RenderSettings.skybox != skyTwo)
                {
                    RenderSettings.skybox = skyTwo;
                    DynamicGI.UpdateEnvironment();
                }
            } else if(tempDone) {
                 if (RenderSettings.skybox != skyThree)
                {
                    RenderSettings.skybox = skyThree;
                    DynamicGI.UpdateEnvironment();
                }
            } else if (waterDone) {
                if (RenderSettings.skybox != skyFour)
                {
                    RenderSettings.skybox = skyFour;
                    DynamicGI.UpdateEnvironment();
                }
            } else if (airDone) {
                if (RenderSettings.skybox != skyFive)
                {
                    RenderSettings.skybox = skyFive;
                    DynamicGI.UpdateEnvironment();
                }
            } else if (radioDone) {
                if (RenderSettings.skybox != skySix)
                {
                    RenderSettings.skybox = skySix;
                    DynamicGI.UpdateEnvironment();
                }
            } else {
                if (RenderSettings.skybox != skyOne)
                {
                    RenderSettings.skybox = skyOne;
                    DynamicGI.UpdateEnvironment();
                }
            }
            */

        //Can Time Pass?
        currentTime += Time.deltaTime;  //UpdateTime

        //Changes at 4-8-12-16-18-20 minutes
        if (currentTime < dayLength * 2 / 10)
        {
            if (RenderSettings.skybox != skyOne)
            {
                RenderSettings.skybox = skyOne;
                DynamicGI.UpdateEnvironment();
            }
            else if (dayLength * 2 / 10 <= currentTime && currentTime <= dayLength * 4 / 10)
            {
                if (RenderSettings.skybox != skyTwo)
                {
                    RenderSettings.skybox = skyTwo;
                    DynamicGI.UpdateEnvironment();
                }
            }
            else if (dayLength * 4 / 10 <= currentTime && currentTime <= dayLength * 6 / 10)
            {
                if (RenderSettings.skybox != skyThree)
                {
                    RenderSettings.skybox = skyThree;
                    DynamicGI.UpdateEnvironment();
                }
            }
            else if (dayLength * 6 / 10 <= currentTime && currentTime <= dayLength * 8 / 10)
            {
                if (RenderSettings.skybox != skyFour)
                {
                    RenderSettings.skybox = skyFour;
                    DynamicGI.UpdateEnvironment();
                }
            }
            else if (dayLength * 8 / 10 <= currentTime && currentTime <= dayLength * 9 / 10)
            {
                if (RenderSettings.skybox != skyFive)
                {
                    RenderSettings.skybox = skyFive;
                    DynamicGI.UpdateEnvironment();
                }
            }
            else if (dayLength * 9 / 10 <= currentTime && currentTime <= dayLength)
            {
                if (RenderSettings.skybox != skySix)
                {
                    RenderSettings.skybox = skySix;
                    DynamicGI.UpdateEnvironment();
                }
            }
            else if (currentTime >= dayLength)
            {
                if (RenderSettings.skybox != skySeven)
                {
                    RenderSettings.skybox = skySeven;
                    DynamicGI.UpdateEnvironment();
                }
            }
        }
    }
}

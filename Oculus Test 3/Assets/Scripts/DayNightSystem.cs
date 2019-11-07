using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//skybox updater
//REQUIRES 7 MATERIALS && 1 GameObject IN SCENE

public class DayNightSystem : MonoBehaviour
{
    public float currentTime = 0f;          //current currentTime
    public float dayLength = 1200f;          //DayLength = 20 minutes

    //Skybox References
    public Material skyOne;					//skybox 1
    public Material skyTwo;					//skybox 2
    public Material skyThree;				//skybox 3
    public Material skyFour;				//skybox 4
    public Material skyFive;                //skybox 5
    public Material skySix;                 //skybox 6
    public Material skySeven;               //skybox 7

    void Update()
    {

        //Can Time Pass?
        currentTime += Time.deltaTime;  //UpdateTime
        dayCycle();                     //Skybox Updater

        //Change Skybox and UpdateEnvironment
        void dayCycle()
        {
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
}
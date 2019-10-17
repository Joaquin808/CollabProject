using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Time of Day Tracker, SkyBox Changer and DayCount Tracker
//Sydney Brown 9-4-2019

//CURRENT DAY LENGTH IS 60 SECONDS: ALL TIME TRIGGERS HARD CODED VALUES

public class SkyboxUpdater : MonoBehaviour
{

    public float dayTime = 0f;  //startTime
    public float maxTime = 600f; //60seconds
    public int dayTrack = 1;    //current day
    public bool EndOfDay = false;

    //Skybox References
    public Material skyOne;		//skybox 1
    public Material skyTwo;		//skybox 2
    public Material skyThree;	//skybox 3
    public Material skyFour;	//skybox 4
    public Material skyFive;	//skybox 5

    // Start is called before the first frame update
    void Start() {

    }
    // Update is called once per frame
    void Update() {
        dayTime += Time.deltaTime;  //increment time

        //Reset Time & Update DayTrack
        if (dayTime >= maxTime) {   
            dayTime = 0.0f;        //reset time
            dayTrack++;            //increment day count
        }

        //Change Skybox and reRender
		//No Change until 1/6 trigger
        if (maxTime * 1/6  <= dayTime && dayTime <= maxTime * 2/6) {	//First
			if (RenderSettings.skybox != skyOne) {	
				RenderSettings.skybox = skyOne;
				DynamicGI.UpdateEnvironment();
			}
        } else if (maxTime * 2/6 <= dayTime && dayTime <= maxTime * 3/6) {
			if (RenderSettings.skybox != skyTwo) {
				RenderSettings.skybox = skyTwo;
				DynamicGI.UpdateEnvironment();
			}
        } else if (maxTime * 3/6 <= dayTime && dayTime <= maxTime * 4/6) {
			if (RenderSettings.skybox != skyThree) {
				RenderSettings.skybox = skyThree;
				DynamicGI.UpdateEnvironment();
			}
        } else if (maxTime * 4/6 <= dayTime && dayTime <= maxTime * 5/6) {
			if (RenderSettings.skybox != skyFour) {
				RenderSettings.skybox = skyFour;
				DynamicGI.UpdateEnvironment();
			}
        } else if (maxTime * 5/6 <= dayTime && dayTime <= maxTime) {	//Last
			if (RenderSettings.skybox != skyFive) {
				RenderSettings.skybox = skyFive;
				DynamicGI.UpdateEnvironment();
			}
        }

    }
}
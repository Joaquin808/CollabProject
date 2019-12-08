using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject keycard;
    Objectives objectives;
    PutOnHelmet PutOnHelmet;
    OVRScreenFade OVRScreenFade;



    // Start is called before the first frame update
    void Start()
    {
        objectives = GameObject.Find("OVRPlayerController").GetComponent<Objectives>();
        PutOnHelmet = GameObject.Find("OVRPlayerController").GetComponent<PutOnHelmet>();
        OVRScreenFade = GameObject.Find("CenterEyeAnchor").GetComponent<OVRScreenFade>();
    }


    void OnTriggerEnter(Collider other)
    {
       if(other.gameObject == keycard && objectives.ObjectiveNumber == 6 && PutOnHelmet.isHelmetOn)
        {
            OVRScreenFade.FadeOut();
            SceneManager.LoadScene("TitleScene");
        }
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Temperature Puzzle, Slider Mechanics

public class TemperatureSlider : MonoBehaviour
{
    private bool isStopped;
    public bool puzzleComplete = false;

    float x, y, z;
    public float correctValue1, correctValue2;
    float stoppedValue;
    public float speed;

    int TypeofAlert;

    private Renderer sliderRenderer;
    public GameObject slider; //Used to call gameobject used for sliding puzzle
    public GameObject lever; //Used to call for Lever gameobject to stop slider
    public GameObject needle;
    Vector3 pos1, pos2;
    public Alerts alerts; //call to alerts script
    public AudioSource leverClick; //Used to get audio source for lever click


    // Start is called before the first frame update
    void Start()
    {
        x = slider.transform.localPosition.x;
        y = slider.transform.localPosition.y;
        z = slider.transform.localPosition.z;
        pos1 = new Vector3(x + 145, y, z);  //Gets max position of object for slider
        pos2 = new Vector3(x, y, z); //Gets min position for sliding object
        sliderRenderer = slider.GetComponent<Renderer>();

        leverClick.GetComponent<AudioSource>();

        //GameObject statusAlert = GameObject.Find("Inventory/MenuCanvas"); //GameObject to access Alerts script
        //alerts = statusAlert.GetComponent<Alerts>();

    }

    // Update is called once per frame
    void Update()
    {
        BarMovement();
    }

    //Sets up movement for sliding bar
    void BarMovement() 
    {
        if (isStopped == false)
        {
            slider.transform.localPosition = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
        }

    }
   
    //Detects if lever is triggered to stop slider
    void OnTriggerEnter(Collider other)
    {
        leverClick.Play(0);
        if (other.gameObject.tag == "Lever")
        {
            stoppedValue = slider.transform.localPosition.x;
            if (stoppedValue >= correctValue1 && stoppedValue <= correctValue2)
            {
                isStopped = true;
                sliderRenderer.material.SetColor("_Color", Color.green);
                alerts.IsAlertActive = false;
            }
            else
            {
                Debug.Log("Incorrect value");
            }
            //Use to check if lever is working
        }
    }

    void OnBreak()
    {
        /*alerts.AlertType = 3;
        alerts.ActivateAlert("Temperature critical!", alerts.AlertType);
        Instantiate(needle,spawnpoint);*/
    }


}

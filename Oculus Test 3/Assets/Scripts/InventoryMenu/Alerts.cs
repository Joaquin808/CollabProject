using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alerts : MonoBehaviour
{
    public Text AlertTypeText;
    public GameObject AlertSection;
    public bool IsAlertActive = false;
    public Text Timer;
    float TimerSeconds = 0f;
    float TimerMinutes = 5f;
    public int AlertType;
    public GameObject FoodBar;
    public GameObject WaterBar;
    public GameObject AirBar;
    public GameObject TempBar;
    GameObject[] Indicator;
    float time = 0;
    bool visible = false;
    public OpenInventory Inventory;
    public AudioSource AlertSound;
    public DayNightSystem DayCycle;

    // Start is called before the first frame update
    void Start()
    {
        // sets the color of each status bar to green at the beginning
        FoodBar.GetComponent<Image>().material.color = new Color(0f, 1f, 0f, 1f);
        WaterBar.GetComponent<Image>().material.color = new Color(0f, 1f, 0f, 1f);
        AirBar.GetComponent<Image>().material.color = new Color(0f, 1f, 0f, 1f);
        TempBar.GetComponent<Image>().material.color = new Color(0f, 1f, 0f, 1f);

        Indicator = GameObject.FindGameObjectsWithTag("AlarmLight");
        for (int i = 0; i < Indicator.Length; i++ )
        {
            Indicator[i].SetActive(false);
        }
       
        AlertSection.SetActive(false);
        AlertType = Random.Range(0, 3);
        //ActivateAlert("Your Air is going bad.", AlertType); Turned off to stop alarm noise at start
    }

    // Update is called once per frame
    void Update()
    {
        if (DayCycle.endOfDay)
        {
            ActivateAlert("Get your ass to sleep", 4);
        }

        if (IsAlertActive)
        {
            time += Time.deltaTime;
            if (time >= 1)
            {
                FlashIndicator();
                time = 0;
            }

            TimerSeconds -= Time.deltaTime;
            Timer.text = "Time Left: " + TimerMinutes.ToString("0:") + TimerSeconds.ToString("00");
            ReduceTimer();

            if (Inventory.IsActive)
            {
                Timer.GetComponent<Text>().material.color = new Color(1f, 1f, 1f, 1f);
            }
            else
            {
                Timer.GetComponent<Text>().material.color = new Color(1f, 1f, 1f, 0f);
            }
        }
    }

    public void ActivateAlert(string AlertText, int TypeOfAlert)
    {
        AlertType = TypeOfAlert;

        switch (AlertType)
        {
            case 0://food
            case 1://water
                TimerMinutes = 10;
                break;
            case 2://air
            case 3://temperature
                TimerMinutes = 5;
                break;
            case 4://bed time
                // Flash lights
                // AI tells you to get your ass to sleep
                // Set two minute timer for player to go to bed, if they don't, they die 
                TimerMinutes = 2;
                break;
        }

        IsAlertActive = true;
        AlertTypeText.text = AlertText;
        AlertSection.SetActive(true);
        SetAlertType();
    }

    void ReduceTimer()
    {
        if (TimerSeconds <= 0)
        {
            TimerMinutes -= 1f;
            TimerSeconds = 59;
            if (TimerMinutes <= 2 && TimerSeconds <= 0)
            {
                switch (AlertType)
                {
                    // changes the corresponding status bar to red when the timer gets to 2 minutes to indicate that the player has little time to fix the issue
                    case 0:
                        FoodBar.GetComponent<Image>().material.color = new Color(1f, 0f, 0f, 1f);
                        break;
                    case 1:
                        WaterBar.GetComponent<Image>().material.color = new Color(1f, 0f, 0f, 1f);
                        break;
                    case 2:
                        AirBar.GetComponent<Image>().material.color = new Color(1f, 0f, 0f, 1f);
                        break;
                    case 3:
                        TempBar.GetComponent<Image>().material.color = new Color(1f, 0f, 0f, 1f);
                        break;
                }
            }

            if (TimerMinutes <= 0 && TimerSeconds <= 0)
            {
                // ends the game when time is out
                EndGame();
            }
        }
    }

    void FlashIndicator()
    {
        // flashes the red light to indicate that something is wrong
        if (!visible)
        {
            for (int i = 0; i < Indicator.Length; i++)
            {
                Indicator[i].SetActive(true);
            }
            visible = true;

        }
        else
        {
            for (int i = 0; i < Indicator.Length; i++)
            {
                Indicator[i].SetActive(false);
            }

            visible = false;
        }
    }

    void SetAlertType()
    {
        // play sound
        AlertSound.GetComponent<AudioSource>();
        AlertSound.Play(0);

        // when an alert becomes active, the corresponding bar turns yellow
        switch (AlertType)
        {
            case 0:
                FoodBar.GetComponent<Image>().material.color = new Color(1f, 1f, 0f, 1f);
                break;
            case 1:
                WaterBar.GetComponent<Image>().material.color = new Color(1f, 1f, 0f, 1f);
                break;
            case 2:
                AirBar.GetComponent<Image>().material.color = new Color(1f, 1f, 0f, 1f);
                break;
            case 3:
                TempBar.GetComponent<Image>().material.color = new Color(1f, 1f, 0f, 1f);
                break;
        }
    }

    void EndGame()
    {
        // put in the code to restart the day
    }

    public void DeactivateAlert(int TypeOfAlert)
    {
        // stop the flashing lights and alert sounds
        IsAlertActive = false;
        for (int i = 0; i < Indicator.Length; i++)
        {
            Indicator[i].SetActive(false);
        }

        switch (TypeOfAlert)
        {
            case 0:
                FoodBar.GetComponent<Image>().material.color = new Color(0f, 1f, 0f, 1f);
                break;
            case 1:
                WaterBar.GetComponent<Image>().material.color = new Color(0f, 1f, 0f, 1f);
                break;
            case 2:
                AirBar.GetComponent<Image>().material.color = new Color(0f, 1f, 0f, 1f);
                break;
            case 3:
                TempBar.GetComponent<Image>().material.color = new Color(0f, 1f, 0f, 1f);
                break;
        }
    }
}

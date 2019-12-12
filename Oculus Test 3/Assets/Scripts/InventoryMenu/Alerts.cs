using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Alerts : MonoBehaviour
{
    public Text AlertTypeText;
    public GameObject AlertSection;
    public bool IsAlertActive = false;
    public Text Timer;
    float TimerSeconds = 0f;
    float TimerMinutes = 5f;
    public int AlertType;
    public GameObject PowerBar;
    public GameObject WaterBar;
    public GameObject AirBar;
    public GameObject TempBar;
    GameObject[] Indicator;
    float time = 0;
    bool visible = false;
    public OpenInventory Inventory;
    public AudioSource AlertSound;
    public DayNightSystem DayCycle;
    bool IsGameOver = false;
    public OVRScreenFade ScreenFadeScript;
    float GameOverTimer = 15.0f;
    public Text GameOverText;
    bool AnyAlertsActive = false;
    float BreakTimerSeconds = 60f;
    float BreakTimerMinutes = 1f;
    float FlashTimer = 0f;
    bool[] AllAlerts = new bool[] {true, true, true, true};
    string[] AlertText = new string[] { "Power Critical", "Temperature Destabalized", "Water Pipes Missing", "Air Filtration Damaged" };
    int ActiveAlert = 0;

    // Start is called before the first frame update
    void Start()
    {
        // sets the color of each status bar to green at the beginning
        PowerBar.GetComponent<Image>().material.color = new Color(1f, 0f, 0f, 1f);
        WaterBar.GetComponent<Image>().material.color = new Color(1f, 1f, 1f, 1f);
        AirBar.GetComponent<Image>().material.color = new Color(1f, 1f, 1f, 1f);
        TempBar.GetComponent<Image>().material.color = new Color(1f, 1f, 1f, 1f);

        //Indicator = GameObject.FindGameObjectsWithTag("AlarmLight");
        /*for (int i = 0; i < Indicator.Length; i++ )
        {
            Indicator[i].SetActive(false);
        }
       
        AlertSection.SetActive(false);*/

        ActiveAlert = 0;
        ActivateAlert("", 0); 
    }

    // Update is called once per frame
    void Update()
    {
        FlashTimer += Time.deltaTime;
        if (FlashTimer >= 1.0f)
        {
            FlashIndicator();
            FlashTimer = 0f;
        }


        /*if (IsAlertActive)
        {
            time += Time.deltaTime;
            if (time >= 1)
            {
                time = 0;
            }

            //TimerSeconds -= Time.deltaTime;
            //Timer.text = "Time Left: " + TimerMinutes.ToString("0:") + TimerSeconds.ToString("00");
            //ReduceTimer();

            /*if (Inventory.IsActive)
            {
                Timer.GetComponent<Text>().material.color = new Color(1f, 1f, 1f, 1f);
            }
            else
            {
                Timer.GetComponent<Text>().material.color = new Color(1f, 1f, 1f, 0f);
            }*/
        //}

        /*if (!AnyAlertsActive)
        {
            BreakTimerSeconds -= Time.deltaTime;
            if (BreakTimerSeconds <= 0)
            {
                BreakTimerSeconds = 60f;
                BreakTimerMinutes -= 1f;
                if (BreakTimerMinutes <= 0)
                {
                    int TypeOfAlert = Random.Range(1, 3);
                    string AlertText = "";
                    switch (TypeOfAlert)
                    {
                        case 1:
                            AlertText = "Your water is going bad";
                            break;
                        case 2:
                            AlertText = "Your air quality is decreasing";
                            break;
                        case 3:
                            AlertText = "Temperature critical";
                            break;
                    }

                    ActivateAlert(AlertText, TypeOfAlert);
                }
            }
        }
            

        if (IsGameOver)
        {
            GameOverTimer -= Time.deltaTime;
            if (GameOverTimer <= 0.0f)
            {
                FadeToTitleScreen();
            }
        }*/
    }

    public void ActivateAlert(string AlertMessage, int TypeOfAlert)
    {
        AlertType = TypeOfAlert;

        /*switch (AlertType)
        {
            case 0://power
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
        }*/

        IsAlertActive = true;
        AlertTypeText.text = AlertText[ActiveAlert];
        AlertSection.SetActive(true);
        SetAlertType();
        AnyAlertsActive = true;
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
                        PowerBar.GetComponent<Image>().material.color = new Color(1f, 0f, 0f, 1f);
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
        /*if (!visible)
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
        }*/
        if (visible)
        {
            for (int i = 0; i < AllAlerts.Length; i++)
            {
                if (AllAlerts[i] == false)
                {
                    switch (i)
                    {
                        case 0:
                            PowerBar.GetComponent<Image>().material.color = new Color(1f, 1f, 1f, 1f);
                            break;
                        case 1:
                            WaterBar.GetComponent<Image>().material.color = new Color(1f, 1f, 1f, 1f);
                            break;
                        case 2:
                            AirBar.GetComponent<Image>().material.color = new Color(1f, 1f, 1f, 1f);
                            break;
                        case 3:
                            TempBar.GetComponent<Image>().material.color = new Color(1f, 1f, 1f, 1f);
                            break;
                    }
                }
                else
                {
                    switch (i)
                    {
                        case 0:
                            PowerBar.GetComponent<Image>().material.color = new Color(1f, 0f, 0f, 0f);
                            break;
                        case 1:
                            WaterBar.GetComponent<Image>().material.color = new Color(1f, 0f, 0f, 0f);
                            break;
                        case 2:
                            AirBar.GetComponent<Image>().material.color = new Color(1f, 0f, 0f, 0f);
                            break;
                        case 3:
                            TempBar.GetComponent<Image>().material.color = new Color(1f, 0f, 0f, 0f);
                            break;
                    }
                }
            }

            visible = false;
        }
        else
        {

            for (int i = 0; i < AllAlerts.Length; i++)
            {
                if (AllAlerts[i] == false)
                {
                    switch (i)
                    {
                        case 0:
                            PowerBar.GetComponent<Image>().material.color = new Color(1f, 1f, 1f, 1f);
                            break;
                        case 1:
                            WaterBar.GetComponent<Image>().material.color = new Color(1f, 1f, 1f, 1f);
                            break;
                        case 2:
                            AirBar.GetComponent<Image>().material.color = new Color(1f, 1f, 1f, 1f);
                            break;
                        case 3:
                            TempBar.GetComponent<Image>().material.color = new Color(1f, 1f, 1f, 1f);
                            break;
                    }
                }
                else
                {
                    switch (i)
                    {
                        case 0:
                            PowerBar.GetComponent<Image>().material.color = new Color(1f, 0f, 0f, 1f);
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
            }
      

            visible = true;
        }
     
    }

    void SetAlertType()
    {
        // play sound
        AlertSound.GetComponent<AudioSource>();
        AlertSound.Play(0);

        // when an alert becomes active, the corresponding bar turns red
        switch (AlertType)
        {
            case 0:
                PowerBar.GetComponent<Image>().material.color = new Color(1f, 0f, 0f, 1f);
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

    void EndGame()
    {
        IsAlertActive = false;
        IsGameOver = true;
        GameObject.Find("GameOverCanvas").GetComponent<Canvas>().enabled = true;
    }

    void FadeToTitleScreen()
    {
        ScreenFadeScript.FadeOut();
        SceneManager.LoadScene("TitleScreen");
    }

    public void DeactivateAlert(int TypeOfAlert)
    {
        // stop the flashing lights and alert sounds
        //IsAlertActive = false;
        ActiveAlert++;
        if (ActiveAlert >= 4)
        {
            AlertTypeText.text = AlertText[ActiveAlert];
            AlertSection.SetActive(false);
            AnyAlertsActive = false;
        }
        /* for (int i = 0; i < Indicator.Length; i++)
         {
             Indicator[i].SetActive(false);
         }*/

        for (int i = 0; i < AllAlerts.Length; i++)
        {
            AllAlerts[TypeOfAlert] = false;
            switch (i)
            {
                case 0:
                    PowerBar.GetComponent<Image>().material.color = new Color(1f, 1f, 1f, 1f);
                    break;
                case 1:
                    WaterBar.GetComponent<Image>().material.color = new Color(1f, 1f, 1f, 1f);
                    break;
                case 2:
                    AirBar.GetComponent<Image>().material.color = new Color(1f, 1f, 1f, 1f);
                    break;
                case 3:
                    TempBar.GetComponent<Image>().material.color = new Color(1f, 1f, 1f, 1f);
                    break;
            }
        }
    }
}

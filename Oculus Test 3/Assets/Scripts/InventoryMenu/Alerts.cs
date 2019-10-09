using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alerts : MonoBehaviour
{
    public Text AlertTypeText;
    public Slider TimerSlider;
    public Canvas AlertCanvas;
    int i = 0;
    bool IsAlertActive = false;
    public GameObject AlertSection;
    public Image Background;
    public Text AlertSectionText;
    bool IsAlertInMenu = false;
    public Text Timer;
    float TimerSeconds = 0f;
    float TimerMinutes = 5f;

    // Start is called before the first frame update
    void Start()
    {
        AlertCanvas.gameObject.SetActive(false);
        TimerSlider.value = 1.0f;
        AlertSection.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        i++;

        if (i >= 600)
        {
            i = 0;
            float ii = Random.Range(1, 3);
            string String = null;
            if (ii == 1)
            {
                String = "You need water";
            }
            else if (ii == 2)
            {
                String = "Your food source is on fire";
            }
            else if (ii == 3)
            {
                String = "Your air quality is declining";
            }
            UpdateAlertTypeText(String);

        }

        if (IsAlertActive)
        {
            DecreaseSliderValue();
        }

        if (IsAlertInMenu)
        {
            FlashBackgroundImage();
            TimerSeconds -= Time.deltaTime;
            ReduceTimer();
        }
    }

    void UpdateAlertTypeText(string AlertText)
    {
        IsAlertActive = true;
        AlertTypeText.text = AlertText;
        AlertCanvas.gameObject.SetActive(true);
        AlertSectionText.text = AlertText;
    }

    void DecreaseSliderValue()
    {
        TimerSlider.value -= 0.001f;
        if (TimerSlider.value == 0f)
        {
            IsAlertActive = false;
            AlertCanvas.gameObject.SetActive(false);
            IsAlertInMenu = true;
            DisplayOnInventoryMenu();
        }
    }

    void DisplayOnInventoryMenu()
    {
        AlertSection.SetActive(true);
        Timer.text = "Time Left To Fix: " + TimerMinutes.ToString("0:") + TimerSeconds.ToString("00");
    }

    void ReduceTimer()
    {
        if (TimerSeconds <= 0)
        {
            TimerMinutes -= 1f;
            TimerSeconds = 59;
        }
    }

    void FlashBackgroundImage()
    {
        bool Visibile = false;
        if (Visibile)
        {
            Background.color = new Color(1f, 0f, 0f, 0f);
            Visibile = true;
        }
        else
        {
            Background.color = new Color(1f, 0f, 0f, 1f);
            Visibile = false;
        }
    }
}

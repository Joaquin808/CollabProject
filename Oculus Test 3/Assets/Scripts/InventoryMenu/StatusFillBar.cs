using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusFillBar : MonoBehaviour
{
    public Slider slider;
    public Text displayText;
    public float currentValue;
    // the time that needs to pass in order for the bar percentage to decrease
    public float TimeToDecreaseBar;
    // the amount for the bar to decrease once the time limit has been reached
    public float DecreaseBarAmount;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
       currentValue = 1f;
        time = 0f;
        slider.value = currentValue;
        displayText.text = (slider.value * 100).ToString("0.00") + "%";
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= TimeToDecreaseBar)
        {
            currentValue = currentValue - DecreaseBarAmount;
            slider.value = currentValue;
            displayText.text = (slider.value * 100).ToString("0.00") + "%";
            time = 0f;
        }
    
    }
}

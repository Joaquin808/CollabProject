using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockTime : MonoBehaviour
{
    public Text DisplayText;
    int Hour = 0;
    int Minutes = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Minutes++;
        DisplayText.text = Hour.ToString("0:") + Minutes.ToString("00");
        if (Minutes >= 60)
        {
            Hour++;
            Minutes = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCanvas : MonoBehaviour
{
    public GameObject Canvas;
    public bool CanvasIsShown = false;

    public void DisplayCanvas()
    {
        if (!CanvasIsShown)
        {
            Canvas.SetActive(true);
            CanvasIsShown = true;
        }
        else
        {
            Canvas.SetActive(false);
            CanvasIsShown = false;
        }
        
    }
}

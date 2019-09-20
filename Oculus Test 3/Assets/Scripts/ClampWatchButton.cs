using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClampWatchButton : MonoBehaviour
{
    public Button watchButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 buttonPos = Camera.main.WorldToScreenPoint(this.transform.position);
        watchButton.transform.position = buttonPos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesPuzzleBreak : MonoBehaviour
{

    public Alerts AlertSystem;
    string AlertString = "Water blockage! Check the pipes to see what went wrong!";
    int AlertType = 1;
    ObjectVisibility objViz;

    // Start is called before the first frame update
    void Start()
    {
        objViz = GetComponent<ObjectVisibility>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void onBreak()
    {

        AlertSystem.ActivateAlert(AlertString, AlertType);
        objViz.isVisible = false;

    }
}

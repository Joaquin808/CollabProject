using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circuit_panel : MonoBehaviour
{
    public GameObject panel;
    public GameObject panelLocker;

    // Start is called before the first frame update
    void Start()
    {
        panelLocker.transform.parent = panel.transform;
        Debug.Log("Panel Locker's Parent: " + panelLocker.transform.parent.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPuzzleBreak : MonoBehaviour
{
    public int AlertType = 3;

    public Alerts alerts; //call to alerts script
    public GameObject needle, needle2;
    public GameObject player;
    public Transform spawnpoint; //Used to get needle and spawn it on the system breaking

    void OnBreak()
    {
        alerts.ActivateAlert("Temperature critical!", AlertType);
        //Instantiate(needle, spawnpoint);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            OnBreak();
        }
    }
}

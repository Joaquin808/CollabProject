using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPuzzleBreak : MonoBehaviour
{
    public int AlertType = 3;

    public Alerts alerts; //call to alerts script
    public GameObject needle;
    public GameObject player;
    public GameObject spawnpoint; //Used to get needle and spawn it on the system breaking

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnBreak()
    {
        alerts.ActivateAlert("Temperature critical!", AlertType);
        Instantiate(needle, spawnpoint.transform);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("Trigger Works");
            OnBreak();
        }
    }
}

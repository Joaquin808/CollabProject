using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPuzzleBreak : MonoBehaviour
{
    public int AlertType = 3;

    public Alerts alerts; //call to alerts script
    public GameObject needle;
    public Transform spawnpoint; //Used to get needle and spawn it on the system breaking

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("It broke!");
            OnBreak();
        }
    }

    void OnBreak()
    {
        alerts.ActivateAlert("Temperature critical!", AlertType);
        Instantiate(needle, spawnpoint);
    }
}

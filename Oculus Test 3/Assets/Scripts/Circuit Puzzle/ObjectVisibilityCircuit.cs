using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectVisibilityCircuit : MonoBehaviour
{
    public GameObject grabbableCircuit;
    Renderer rend;
    public bool SolvedFirstTime = false;

    public PowerOn powerScript;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        Objectives ObjectiveScript = GameObject.Find("OVRPlayerController").GetComponent<Objectives>();
        if (ObjectiveScript.ObjectiveNumber == 4 || SolvedFirstTime)
        {
            if (other.gameObject == grabbableCircuit)
            {
                rend.enabled = true;
                Destroy(other.gameObject);
                powerScript.circuitsConnected++;
                Debug.Log(powerScript.circuitsConnected);
                if (powerScript.powerEnabled)
                {
                    SolvedFirstTime = true;
                }
            }
        }
        
    }
}

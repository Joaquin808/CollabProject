using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectVisibility : MonoBehaviour
{
    List<string> collisionList = new List<string>();
    public bool isVisible = false;
    Renderer rend;
    public string String;
    private GameObject destroyedPipe;
    public GameObject PipeSetPrefab;
    public GameObject spawnLoc;
    public int pipesFixed = 0;
    public Alerts AlertSystem;
    int TypeOfAlert = 1;
    public Pickup InventoryItemRef;
    bool SolvedFirstTime = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        rend.enabled = isVisible;

    }


    void PrintList()
    {
        for (int i = 0; i < collisionList.Count; i++)
        {
            print(collisionList[i]);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        Objectives ObjectiveScript = GameObject.Find("OVRPlayerController").GetComponent<Objectives>();
        if (ObjectiveScript.ObjectiveNumber == 7 || SolvedFirstTime)
        {
            PrintList();
            if (!collisionList.Contains(collision.gameObject.name))
            {
                collisionList.Add(collision.gameObject.name);
            }

            if (collisionList.Contains(String) && collisionList.Contains("Wrench"))
            {
                isVisible = true;
                collisionList.Remove(String);
                collisionList.Remove("Wrench");
                destroyedPipe = GameObject.Find(String);
                Destroy(destroyedPipe);
                pipesFixed++;
                if (pipesFixed == 7)
                {
                    AlertSystem.DeactivateAlert(TypeOfAlert);
                    SolvedFirstTime = true;
                    if (ObjectiveScript.ObjectiveNumber == 7)
                    {
                        ObjectiveScript.SetNextObjective();
                    }
                }
            }
        }
       
    }



    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == String)
        {
            collisionList.Remove(String);

        }

        if (collision.gameObject.tag == "Welder")
        {
            collisionList.Remove("Welder");
        }

    }

    public void spawnPipes()
    {
        Instantiate(PipeSetPrefab, spawnLoc.transform);
    }
}
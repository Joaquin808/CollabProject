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
    public GameObject curvedPipeSpawn;
    public GameObject straightPipeSpawn;
    public GameObject crookedPipeSpawn;
    public GameObject spawnLoc;
    public int pipesFixed = 0;
    public Alerts AlertSystem;
    int TypeOfAlert = 1;

    // Use this for initialization
    void Start()
    {
        
        rend = GetComponent<Renderer>();
        
    }

    // Update is called once per frame
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
        if (!collisionList.Contains(collision.gameObject.name))
        {
            collisionList.Add(collision.gameObject.name);
        }

        if (collisionList.Contains(String) && collisionList.Contains("Welder"))
        {

            isVisible = true;
            collisionList.Remove(String);
            collisionList.Remove("Welder");
            destroyedPipe = GameObject.Find(String);
            Destroy(destroyedPipe);
            pipesFixed++;
            if(pipesFixed == 6)
            {
                AlertSystem.DeactivateAlert(TypeOfAlert);
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
        Instantiate(curvedPipeSpawn, spawnLoc.transform);
        Instantiate(straightPipeSpawn, spawnLoc.transform);
        Instantiate(crookedPipeSpawn, spawnLoc.transform);

    }

}
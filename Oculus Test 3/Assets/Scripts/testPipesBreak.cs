using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPipesBreak : MonoBehaviour
    {

    public GameObject testSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter()
    {
        testSpawn.GetComponent<PipesPuzzleBreak>().onBreak();
    }
}

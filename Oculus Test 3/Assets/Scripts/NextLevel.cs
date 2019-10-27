using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public GameObject cube;
    public GameObject spawn;

    // Start is called before the first frame update
    void Start()
    {
        Transform transform = spawn.GetComponent<Transform>();
    }

    public void SpawnCubes()
    {
        Instantiate(cube, transform);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

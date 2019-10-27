using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenes : MonoBehaviour
{
    public GameObject cube;
    public GameObject spawn;
    /*private static void LoadScene()
    {

    }*/
    void Start()
    {
        Transform transform = spawn.GetComponent<Transform>();
    }
    void CreateCubes()
    {
        Instantiate(cube, transform);
    }
}

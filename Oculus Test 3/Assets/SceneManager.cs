using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public GameObject cube;
    public Transform spawn;
    /*private static void LoadScene()
    {

    }*/

    void CreateCubes()
    {
        Instantiate(cube, spawn);
    }
}

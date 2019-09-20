using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreCubes : MonoBehaviour
{
    public GameObject cubePrefab;

    // Update is called once per frame
    public void Cube()
    {
        Instantiate(cubePrefab);
    }
}

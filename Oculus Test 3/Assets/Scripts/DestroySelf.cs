using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    //GameObject ObjectToDestroy = InventoryPanel.GetComponent<GameObject>();
    //Transform child = InventoryPanel.transform;

    public void Destroy()
    {
        Destroy(gameObject);
    }
}

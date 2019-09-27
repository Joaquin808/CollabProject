using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Pickup", menuName = "InventoryItem/Pickup")]
public class Pickup : InventoryItem
{
    public GameObject ObjectToSpawn;
    public GameObject Hand;
    public bool ItemWasSpawned = false;

    private void Start()
    {
        ItemWasSpawned = false;
    }


    public override void Use()
    {
        base.Use();

        if (ItemWasSpawned)
        {
            return;
        }

        ItemWasSpawned = true;

        GameObject watch = GameObject.FindGameObjectWithTag("Watch");
        GameObject spawned = Instantiate(ObjectToSpawn, watch.transform.position, Quaternion.identity);
        Inventory.Instance.Remove(this);
        Debug.Log("Use");
    }


}

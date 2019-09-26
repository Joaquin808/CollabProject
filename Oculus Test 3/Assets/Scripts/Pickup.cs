using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Pickup", menuName = "InventoryItem/Pickup")]
public class Pickup : InventoryItem
{
    public GameObject ObjectToSpawn;
    public GameObject Hand;

    public override void Use()
    {
        base.Use();
        Instantiate(ObjectToSpawn, Hand.transform);
        Inventory.Instance.Remove(this);
        Debug.Log("Use");
    }


}

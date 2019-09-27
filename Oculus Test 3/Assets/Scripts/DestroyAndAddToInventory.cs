using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndAddToInventory : MonoBehaviour
{
    public Pickup InventoryItemRef;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Inventory.Instance.Add(InventoryItemRef);
            Destroy(gameObject);
        }
    }
}

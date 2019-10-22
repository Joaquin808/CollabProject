using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndAddToInventory : MonoBehaviour
{
    public Pickup InventoryItemRef;
    public bool CanAddToInventory;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            if (InventoryItemRef.ItemType == "Bone")
            {
                if (CanAddToInventory)
                {
                    Inventory.Instance.Add(InventoryItemRef);
                    Destroy(gameObject);
                    return;
                }
            }
            Inventory.Instance.Add(InventoryItemRef);
            Destroy(gameObject);
        }
    }
}

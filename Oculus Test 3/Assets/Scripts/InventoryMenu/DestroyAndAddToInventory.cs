using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndAddToInventory : MonoBehaviour
{
    public Pickup InventoryItemRef;
    public bool CanAddToInventory;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ChipCollider")
        {
            Inventory.Instance.Add(InventoryItemRef);
            Destroy(gameObject);
            if (InventoryItemRef.ItemType == "Journal")
            {
                Inventory.Instance.Add(InventoryItemRef);
                Destroy(gameObject);
                return;
            }
        }

        }
}

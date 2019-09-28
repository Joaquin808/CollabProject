using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> List = new List<InventoryItem>();

    public GameObject Player;
    public GameObject InventoryPanelConsumable;
    public GameObject InventoryPanelTools;
    public int NumberOfInventorySlots = 1;
    public static Inventory Instance;
    public GameObject InventoryPrefab;

    void UpdatePanelSlots()
    {
        int index = 0;
        foreach (Transform child in InventoryPanelConsumable.transform)
        {
            InventorySlotController Slot = child.GetComponent<InventorySlotController>();

            if (index < List.Count)
            {
                Slot.Item = List[index];
            }
            else
            {
                Slot.Item = null;
                Slot.transform.parent = null;
            }

            Slot.UpdateInfo();
            index++;
        }

        foreach (Transform child in InventoryPanelTools.transform)
        {
            InventorySlotController Slot = child.GetComponent<InventorySlotController>();

            if (index < List.Count)
            {
                Slot.Item = List[index];
            }
            else
            {
                Slot.Item = null;
                Slot.transform.parent = null;
            }

            Slot.UpdateInfo();
            index++;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        UpdatePanelSlots();
    }

    public void Add(InventoryItem Item)
    {
        if (List.Contains(Item))
        {
            return;
        }
        else
        {
            if (Item.ItemType == "Tool")
            {
                List.Add(Item);
                Instantiate(InventoryPrefab, InventoryPanelTools.transform);
                UpdatePanelSlots();
            }

            if (Item.ItemType == "Consumable")
            {
                List.Add(Item);
                Instantiate(InventoryPrefab, InventoryPanelConsumable.transform);
                UpdatePanelSlots();
            }

        }
    }

    public void Remove(InventoryItem Item)
    {
        List.Remove(Item);
        UpdatePanelSlots();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> ToolList = new List<InventoryItem>();
    public List<InventoryItem> ResourceList = new List<InventoryItem>();
    public List<InventoryItem> JournalList = new List<InventoryItem>();
    public List<InventoryItem> KeysList = new List<InventoryItem>();

    public GameObject InventoryPanelTools;
    public GameObject InventoryPanelResources;
    public GameObject InventoryPanelJournalEntries;
    public GameObject InventoryPanelKeys;

    public static Inventory Instance;
    public GameObject InventoryPrefab;

    void UpdatePanelSlots()
    {
        int ToolIndex = 0;
        foreach (Transform child in InventoryPanelTools.transform)
        {
            InventorySlotController Slot = child.GetComponent<InventorySlotController>();

            if (ToolIndex < ToolList.Count)
            {
                Slot.Item = ToolList[ToolIndex];
            }
            else
            {
                Slot.Item = null;
                Slot.transform.parent = null;
            }

            Slot.UpdateInfo();
            ToolIndex++;
        }

        int ResourceIndex = 0;
        foreach (Transform child in InventoryPanelResources.transform)
        {
            InventorySlotController Slot = child.GetComponent<InventorySlotController>();

            if (ResourceIndex < ResourceList.Count)
            {
                Slot.Item = ResourceList[ResourceIndex];
            }
            else
            {
                Slot.Item = null;
                Slot.transform.parent = null;
            }

            Slot.UpdateInfo();
            ResourceIndex++;
        }

        int JournalIndex = 0;
        foreach (Transform child in InventoryPanelJournalEntries.transform)
        {
            InventorySlotController Slot = child.GetComponent<InventorySlotController>();

            if (JournalIndex < JournalList.Count)
            {
                Slot.Item = JournalList[JournalIndex];
            }
            else
            {
                Slot.Item = null;
                Slot.transform.parent = null;
            }

            Slot.UpdateInfo();
            JournalIndex++;
        }

        int KeysIndex = 0;
        foreach (Transform child in InventoryPanelKeys.transform)
        {
            InventorySlotController Slot = child.GetComponent<InventorySlotController>();

            if (KeysIndex < KeysList.Count)
            {
                Slot.Item = KeysList[KeysIndex];
            }
            else
            {
                Slot.Item = null;
                Slot.transform.parent = null;
            }

            Slot.UpdateInfo();
            KeysIndex++;
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
        if (Item.ItemType == "Tool")
        {
            if (ToolList.Contains(Item))
            {
                return;
            }

            ToolList.Add(Item);
            Instantiate(InventoryPrefab, InventoryPanelTools.transform);
            UpdatePanelSlots();
        }

        if (Item.ItemType == "Resource")
        {
            if (ResourceList.Contains(Item))
            {
                return;
            }

            ResourceList.Add(Item);
            Instantiate(InventoryPrefab, InventoryPanelResources.transform);
            UpdatePanelSlots();
        }

        if (Item.ItemType == "Journal")
        {
            if (JournalList.Contains(Item))
            {
                return;
            }

            JournalList.Add(Item);
            Instantiate(InventoryPrefab, InventoryPanelJournalEntries.transform);
            UpdatePanelSlots();
        }

        if (Item.ItemType == "Key")
        {
            if (KeysList.Contains(Item))
            {
                return;
            }

            KeysList.Add(Item);
            Instantiate(InventoryPrefab, InventoryPanelKeys.transform);
            UpdatePanelSlots();
        }
    }

    public void Remove(InventoryItem Item)
    {
        if (Item.ItemType == "Tool")
        {
            ToolList.Remove(Item);
        }

        if (Item.ItemType == "Resource")
        {
            ResourceList.Remove(Item);
        }

        if (Item.ItemType == "Journal")
        {
            JournalList.Remove(Item);
        }

        if (Item.ItemType == "Key")
        {
            KeysList.Remove(Item);
        }

        UpdatePanelSlots();
    }
}

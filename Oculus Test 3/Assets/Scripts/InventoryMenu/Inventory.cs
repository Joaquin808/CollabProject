using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> List = new List<InventoryItem>();
    public List<InventoryItem> ToolList = new List<InventoryItem>();
    public List<InventoryItem> ConsumableList = new List<InventoryItem>();

    public GameObject Player;
    public GameObject InventoryPanel;
    public GameObject InventoryPanelTools;
    public GameObject InventoryPanelConsumable;
    public int NumberOfInventorySlots = 1;
    public static Inventory Instance;
    public GameObject InventoryPrefab;
    public bool TabInventory;

    void UpdatePanelSlots()
    {
        if (!TabInventory)
        {
            int index = 0;
            foreach (Transform child in InventoryPanel.transform)
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
        else
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

            int ConsumableIndex = 0;
            foreach (Transform child in InventoryPanelConsumable.transform)
            {
                InventorySlotController Slot = child.GetComponent<InventorySlotController>();

                if (ConsumableIndex < ConsumableList.Count)
                {
                    Slot.Item = ConsumableList[ConsumableIndex];
                }
                else
                {
                    Slot.Item = null;
                    Slot.transform.parent = null;
                }

                Slot.UpdateInfo();
                ConsumableIndex++;
            }         
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

        if (!TabInventory)
        {
            if (List.Contains(Item))
            {
                return;
            }

            List.Add(Item);
            Instantiate(InventoryPrefab, InventoryPanel.transform);
            UpdatePanelSlots();
        }
        else
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

            if (Item.ItemType == "Consumable")
            {
                if (ConsumableList.Contains(Item))
                {
                    return;
                }

                ConsumableList.Add(Item);
                Instantiate(InventoryPrefab, InventoryPanelConsumable.transform);
                UpdatePanelSlots();
            }
        }
    }

    public void Remove(InventoryItem Item)
    {
        if (!TabInventory)
        {
            List.Remove(Item);
        }
        else 
        {
           if (Item.ItemType == "Tool")
           {
                ToolList.Remove(Item);
           }

           if (Item.ItemType == "Consumable")
           {
                ConsumableList.Remove(Item);
           }
        }
      
        UpdatePanelSlots();
    }
}

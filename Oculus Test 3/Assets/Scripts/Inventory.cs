﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> List = new List<InventoryItem>();

    public GameObject Player;
    public GameObject InventoryPanel;
    public int NumberOfInventorySlots = 1;
    public static Inventory Instance;
    public GameObject InventoryPrefab;

    void UpdatePanelSlots()
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
            List.Add(Item);
        }

        Instantiate(InventoryPrefab, InventoryPanel.transform);
        UpdatePanelSlots();
    }

    public void Remove(InventoryItem Item)
    {
        List.Remove(Item);
        UpdatePanelSlots();
    }
}

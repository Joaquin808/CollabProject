using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalEntry : MonoBehaviour
{
    // gets the text from the Journal Entry Inventory Item to display on its corresponding Journal Entry popup
    public Pickup pickup;

    // Start is called before the first frame update
    void Start()
    {
        Text JournalEntry = GetComponent<Text>();
        JournalEntry.text = pickup.JournalEntry;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveJournalEntry : MonoBehaviour
{
    GameObject JournalCanvas;

    private void Start()
    {
        JournalCanvas = GameObject.FindGameObjectWithTag("JournalCanvas");
    }

    public void Destroy()
    {
        JournalCanvas.transform.DetachChildren();
    }
}

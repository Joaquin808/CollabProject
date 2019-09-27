using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : ScriptableObject
{
    public string Title;
    public string Description;

    public virtual void Use()
   {
     
   }
}

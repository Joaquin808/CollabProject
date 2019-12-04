using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyAndAddToInventory : MonoBehaviour
{
    public Pickup InventoryItemRef;
    //public bool CanAddToInventory;
    bool ItemWasAdded = false;
    public Text ItemAddedText;
    float Timer, spawnTimer;

    void Start()
    {
        ItemAddedText = GameObject.Find("ItemAddedTextParent").GetComponentInChildren<Text>();
    }

    void Update()
    {
        if (ItemWasAdded)
        {
            Timer += Time.deltaTime;
            if (Timer >= 5)
            {
                ItemAddedText.text = "";
                ItemWasAdded = false;
                Timer = 0;
            }
            else
            {
                ItemAddedText.text = InventoryItemRef.name + " was added to the inventory";
            }
        }
   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ChipCollider")
        {
            //Play Animation
            gameObject.GetComponentInChildren<SpawnEffect>().Despawn();
            //Wait 3 seconds for animation to end, then addtoinventory
            spawnTimer = 0;
            spawnTimer += Time.deltaTime;
            if(spawnTimer >= 3)
            {
                Inventory.Instance.Add(InventoryItemRef);
                Renderer rend = gameObject.GetComponentInChildren<Renderer>();
                rend.enabled = false;
                Rigidbody rigid = gameObject.GetComponent<Rigidbody>();
                rigid.detectCollisions = false;
                ItemWasAdded = true;
            }
        }
    }

}

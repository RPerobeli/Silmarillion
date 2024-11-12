using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{ 
    public InventoryItem InventoryItem;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var player = collision.gameObject.GetComponent<FeanorController>();
            if(player.Inventory.Count < 12)
            {
                player.AddToInventory(InventoryItem);
                Debug.Log("Pegou Item");
                Destroy(this.gameObject);
            }
            else
            {
                //Som de não pick up
            }
        }
    }
}

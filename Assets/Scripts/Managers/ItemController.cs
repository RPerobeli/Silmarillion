using Assets.Scripts.Model;
using System.Linq;
using UnityEngine;

public class ItemController : MonoBehaviour
{ 
    public Item Item;
    


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var player = collision.gameObject.GetComponent<FeanorController>();
            InventoryItem itemToAdd = player.Inventory.FirstOrDefault(i => i.Item.Id == Item.Id);
            if (itemToAdd is not null)
            {
                itemToAdd.Quantity++;
                Debug.Log("Pegou Item");
                Destroy(this.gameObject);
            }
            else
            {
                if (player.Inventory.Count < 12)
                {
                    itemToAdd = new InventoryItem()
                    {
                        Item = Item,
                        Quantity = 1
                    };

                    player.AddToInventory(itemToAdd);
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
}

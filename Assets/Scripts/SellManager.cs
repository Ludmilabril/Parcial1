using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SellManager : MonoBehaviour
{
    public Inventory playerInventory;
    public ManagersMoney moneyManager;
    public ItemClick itemClick; // Referencia al sistema de selección de ítems

    private readonly Dictionary<string, int> itemPrices = new Dictionary<string, int>
    {
        { "Tomato", 10 },
        { "Carrot", 20 },
        { "Potato", 30 }
    };

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SellItems"))
        {
            SellItems();
        }
    }

    private void SellItems()
    {
        if (playerInventory == null || moneyManager == null || itemClick == null)
        {
            return;
        }

        int totalMoneyEarned = 0;
        var itemsToRemove = new List<IInventoryItem>();

        foreach (IInventoryItem item in playerInventory.GetItems())
        {
            if (itemPrices.TryGetValue(item.Name, out int price))
            {
                totalMoneyEarned += price;
                itemsToRemove.Add(item);
            }
        }

        foreach (IInventoryItem item in itemsToRemove)
        {
            if (itemClick.currentItem == item)
            {
                GameObject itemObject = (item as MonoBehaviour)?.gameObject;
                if (itemObject != null)
                {
                    itemObject.SetActive(false); 
                }
                itemClick.ClearCurrentItem(); 
            }

            playerInventory.RemoveItem(item);
        }

        moneyManager.addMoney(totalMoneyEarned);
    }
}
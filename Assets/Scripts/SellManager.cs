using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SellManager : MonoBehaviour
{
    public Inventory playerInventory;
    public ManagersMoney moneyManager;
    public ItemClick itemClick; 
    private readonly Dictionary<string, Dictionary<QualityType, int>> itemPrices = new Dictionary<string, Dictionary<QualityType, int>>
{
    { "Tomato", new Dictionary<QualityType, int> { { QualityType.Low, 5 }, { QualityType.Medium, 10 }, { QualityType.High, 20 } } },
    { "Carrot", new Dictionary<QualityType, int> { { QualityType.Low, 10 }, { QualityType.Medium, 15 }, { QualityType.High, 25 } } },
    { "Potato", new Dictionary<QualityType, int> { { QualityType.Low, 20 }, { QualityType.Medium, 25 }, { QualityType.High, 35 } } }
};

    // Lista de frutas y verduras que se pueden vender
    private readonly HashSet<string> sellableItems = new HashSet<string>
{
    "Tomato",
    "Carrot",
    "Potato"
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
            Debug.LogError("SellManager: Referencias faltantes.");
            return;
        }

        int totalMoneyEarned = 0;
        var itemsToRemove = new List<IInventoryItem>();

        foreach (IInventoryItem item in playerInventory.GetItems())
        {
            // Solo procesar si el objeto está en la lista de productos vendibles
            if (sellableItems.Contains(item.Name))
            {
                if (item.HasQuality)
                {
                    Debug.Log($"Vendiendo {item.Name} con calidad: {item.Quality}");
                    if (itemPrices.TryGetValue(item.Name, out var qualityPrices) &&
                        qualityPrices.TryGetValue(item.Quality, out int price))
                    {
                        totalMoneyEarned += price;
                        itemsToRemove.Add(item);
                    }
                    else
                    {
                        Debug.LogError($"Precio no encontrado para {item.Name} con calidad {item.Quality}");
                    }
                }
            }
        }

        // Remover los objetos vendidos del inventario
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

        // Actualizar el dinero del jugador
        moneyManager.addMoney(totalMoneyEarned);

        Debug.Log($"Dinero total ganado: {totalMoneyEarned}");
    }
}
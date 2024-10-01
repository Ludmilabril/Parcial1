using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    private const int SLOTS = 6;
    private List<IInventoryItem> mItems = new List<IInventoryItem>();
    public event EventHandler <InventoryEventsArgs> ItemAdded;
    public event EventHandler<InventoryEventsArgs> ItemUsed;

    public List<IInventoryItem> GetItems()
    {
        return mItems;
    }
    public void UseItem(IInventoryItem item)
    {
        GameObject goItem = (item as MonoBehaviour).gameObject;

        if (goItem != null)
        {
            goItem.SetActive(true); 
        }

        if (ItemUsed != null)
        {
            ItemUsed(this, new InventoryEventsArgs(item)); 
        }
    }
    public void addItem(IInventoryItem item)
    {
        if (mItems.Count < SLOTS)
        {
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
            if (collider.enabled)
            {
                collider.enabled = false;
                mItems.Add(item);
                item.OnPickUp();

                if (ItemAdded != null)
                {
                    ItemAdded(this, new InventoryEventsArgs(item));
                }
            }
        }
    }
}

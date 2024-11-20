using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    private const int SLOTS = 6;
    private List<IInventoryItem> mItems = new List<IInventoryItem>();
    public event EventHandler<InventoryEventsArgs> ItemAdded;
    public event EventHandler<InventoryEventsArgs> ItemRemoved; 
    public event EventHandler<InventoryEventsArgs> ItemUsed;

    public List<IInventoryItem> GetItems()
    {
        return mItems;
    }


    public void UseItem(IInventoryItem item)
    {
        if (mItems.Contains(item))
        {
            GameObject goItem = (item as MonoBehaviour).gameObject; 
            goItem.SetActive(true);
            ItemUsed?.Invoke(this, new InventoryEventsArgs(item));
        }
    }

    public void addItem(IInventoryItem item)
    {
        if (mItems.Count < SLOTS && !mItems.Contains(item))
        {
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
            if (collider != null && collider.enabled)
            {
                collider.enabled = false;
                mItems.Add(item);
                item.OnPickUp(); 
                ItemAdded?.Invoke(this, new InventoryEventsArgs(item));
            }
        }
    }

    public void RemoveItem(IInventoryItem item)
    {
        if (mItems.Contains(item))
        {
            mItems.Remove(item);
            ItemRemoved?.Invoke(this, new InventoryEventsArgs(item));
        }
 
    }
}
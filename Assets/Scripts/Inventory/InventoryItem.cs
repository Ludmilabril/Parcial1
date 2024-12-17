using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IInventoryItem
{
    string Name { get; }
    Sprite image { get; }
    bool HasQuality { get; } // Nueva propiedad para distinguir objetos
    QualityType Quality { get; } // Solo se usa si el objeto tiene calidad

    void OnPickUp();
}

public enum QualityType
{
    Low,
    Medium,
    High
}
public class InventoryEventsArgs: EventArgs
{
    public InventoryEventsArgs(IInventoryItem item)
    {
        Item = item;
    }
    public IInventoryItem Item;
}

public class InventoryItem : MonoBehaviour
{

   

}

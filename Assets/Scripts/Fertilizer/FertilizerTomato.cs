using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FertilizerTomato : MonoBehaviour
{
    public int cantIngridients = 2;
    public int ingridientesRec;
    public CapsuleCollider capsuleCollider;
    public IInventoryItem inventoryitem;
    public Inventory inventory;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WoodAsh"))
        {
            ingridientesRec += 1;
            other.gameObject.SetActive(false);
            inventoryitem = other.GetComponent<IInventoryItem>();
            if (inventoryitem != null)
            {
                inventory.RemoveItem(inventoryitem);
            }
        }
        if (other.CompareTag("Vinegar"))
        {
            ingridientesRec += 1;
            other.gameObject.SetActive(false);
            inventoryitem = other.GetComponent<IInventoryItem>();
            if (inventoryitem != null)
            {
                inventory.RemoveItem(inventoryitem);
            }
        }

        if (cantIngridients == ingridientesRec)
        {
            capsuleCollider.enabled = true;
        }
    }
}

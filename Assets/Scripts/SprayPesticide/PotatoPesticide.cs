using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoPesticide : MonoBehaviour
{
    public int ingridients;
    public int ingridientsMax = 2;
    public CapsuleCollider ReadySpray;

    public IInventoryItem inventoryitem;
    public Inventory inventory;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("IngridientsPotato"))
        {
            ingridients++;
            inventoryitem = other.GetComponent<IInventoryItem>();
            if (inventoryitem != null)
            {
                inventory.RemoveItem(inventoryitem);
            }
            other.gameObject.SetActive(false);
            //Destroy(other.gameObject); 
        }

        if (ingridients == ingridientsMax)
        {
            ReadySpray.enabled = true; // Activa el BoxCollider cuando se alcanzan los ingredientes necesarios
        }
    }
}

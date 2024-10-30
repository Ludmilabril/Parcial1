using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Eat : MonoBehaviour
{
    public bool CanEat;
    public HealthAndHunger healthAndHunger;
    public Inventory inventory; 
    private IInventoryItem currentItem; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CanEat = true;
            currentItem = GetComponent<IInventoryItem>(); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CanEat = false;
        }
    }

    private void Update()
    {
        if (CanEat && Input.GetKey(KeyCode.E))
        {
            healthAndHunger.SumHunger(10);
            RemoveItem();
        }
    }

    private void RemoveItem()
    {
        if (currentItem != null && inventory != null)
        {
            inventory.RemoveItem(currentItem); 
        }

        gameObject.SetActive(false); 
    }
}
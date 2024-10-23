using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickGardenShovel : MonoBehaviour, IInventoryItem
{
    public string Name { get { return "GardenShovel"; } }
    public Sprite _image;
    public Sprite image
    {
        get { return _image; }
    }

    public void OnPickUp()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory playerInventory = other.GetComponent<Inventory>();
            if (playerInventory != null)
            {
                playerInventory.addItem(this.GetComponent<IInventoryItem>());
            }

        }
    }
}

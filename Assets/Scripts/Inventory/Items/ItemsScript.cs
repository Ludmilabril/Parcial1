using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemsScript : MonoBehaviour, IInventoryItem
{
    public string Name { get { return "TomatoSeeds"; } }

    public Sprite _image;
    public bool HasQuality { get { return false; } } // No tiene calidad
    public QualityType Quality { get { return QualityType.Low; } } // No se usa
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

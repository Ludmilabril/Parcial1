using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoPlant : MonoBehaviour, IInventoryItem
{
    public string Name { get { return "Potato"; } }
    public Sprite _image;
    public Sprite image { get { return _image; } }
    public bool HasQuality { get { return true; } }
    public QualityType Quality { get; private set; }

    private bool isCollected = false;

    private void Start()
    {
        Quality = QualityType.Medium; 
    }
    public void OnPickUp()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            Inventory playerInventory = other.GetComponent<Inventory>();
            QualitySliderManager qualityManager = FindObjectOfType<QualitySliderManager>();

            if (playerInventory != null && qualityManager != null)
            {
                isCollected = true;

                Quality = qualityManager.GetCurrentQualityType();

                CollectFruit(playerInventory);
            }
           
        }
    }
    private void CollectFruit(Inventory inventory)
    {
        inventory.addItem(this); // Agrega el ítem al inventario
        gameObject.SetActive(false); // Oculta el objeto del mundo
        gameObject.GetComponent<Collider>().enabled = false; // Desactiva el collider
        Debug.Log($"Vendiendo {Name} con calidad: {Quality}");
    }

}

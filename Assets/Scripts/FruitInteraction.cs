using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitInteraction : MonoBehaviour, IInventoryItem
{
    public QuestManager manager;
    public string Name { get { return "Tomato"; } }
    public Sprite _image;
    public Sprite image { get { return _image; } }
    public bool HasQuality { get { return true; } }
    public QualityType Quality { get; private set; }

    private bool isCollected = false;

    public void SetQuality(QualityType quality)
    {
        Quality = quality;
    }
    public void Initialize(QualitySliderManager assignedQualityManager)
    {
        Quality = assignedQualityManager.GetCurrentQualityType();
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
            Text questText = manager.Quest5.GetComponent<Text>();
            if (manager.CantQuest == 4)
            {
                manager.CantQuest += 1;
                questText.color = Color.green;
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

    public void OnPickUp()
    {
        gameObject.SetActive(false);
    }
   
 
}
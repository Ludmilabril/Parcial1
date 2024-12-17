using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plants : MonoBehaviour, IInventoryItem
{
    public QuestManager manager;
    public string Name { get { return "Plants"; } }
    public bool HasQuality { get { return false; } } // No tiene calidad
    public QualityType Quality { get { return QualityType.Low; } } // No se usa

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
            Text questText = manager.Quest5.GetComponent<Text>();

            if (questText != null)
            {
                manager.CantQuest += 1;
                questText.color = Color.green;
            }

        }
    }

}

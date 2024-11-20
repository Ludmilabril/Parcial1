using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FruitInteraction : MonoBehaviour, IInventoryItem
{
    public QuestManager manager;
    public string Name { get { return "Seeds"; } }

    public Sprite _image;
    public Sprite image
    {
        get { return _image; }
    }
    private bool isCollected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            Inventory playerInventory = other.GetComponent<Inventory>();
            if (playerInventory != null)
            {
                isCollected = true;
                CollectFruit(playerInventory);
                Text questText = manager.Quest5.GetComponent<Text>();

                if (questText != null)
                {
                    manager.CantQuest += 1;
                    questText.color = Color.green;
                }
            }
        }
    }

    private void CollectFruit(Inventory inventory)
    {
        inventory.addItem(this); 
        gameObject.SetActive(false); 
        gameObject.GetComponent<Collider>().enabled = false;
    }

    public void OnPickUp()
    {
        gameObject.SetActive(false);
    }
   

 
}
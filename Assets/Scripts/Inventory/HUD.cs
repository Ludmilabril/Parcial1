using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class HUD : MonoBehaviour
{
    public Inventory Inventory;
    public GameObject MessagePanel;

    private void Start()
    {
        Inventory.ItemAdded += InventoryScript_ItemAdded;
        Inventory.ItemRemoved += InventoryScript_ItemRemoved;
    }

    public void InventoryScript_ItemAdded(object sender, InventoryEventsArgs e)
    {
        UpdateInventoryUI();
    }

    public void InventoryScript_ItemRemoved(object sender, InventoryEventsArgs e)
    {
        UpdateInventoryUI();
    }

    private void UpdateInventoryUI()
    {
        Transform inventoryPanel = transform.Find("InventoryPanel");
        List<IInventoryItem> items = Inventory.GetItems();

        foreach (Transform slot in inventoryPanel)
        {
            Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();
            image.enabled = false;
            image.sprite = null;
        }

        for (int i = 0; i < items.Count; i++)
        {
            Transform slot = inventoryPanel.GetChild(i);
            Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();

            image.enabled = true;
            image.sprite = items[i].image;
        }
    }

    public void OpenMessagePanel(string text)
    {
        MessagePanel.SetActive(true);
    }

    public void CloseMessagePanel()
    {
        MessagePanel.SetActive(false);
    }
}
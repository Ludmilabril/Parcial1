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

    }

    public void InventoryScript_ItemAdded(object sender, InventoryEventsArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel");

        foreach (Transform Slot in inventoryPanel)
        {
            Image image = Slot.GetChild(0).GetChild(0).GetComponent<Image>();

            if (!image.enabled)
            {
                image.enabled = true;
                image.sprite = e.Item.image;

                break;

            }
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

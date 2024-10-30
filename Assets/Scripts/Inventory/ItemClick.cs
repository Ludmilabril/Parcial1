using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemClick : MonoBehaviour
{
    public Inventory inventory;
    public GameObject inventoryPanel;
    private Color colorInicial;

    private Image currentItemImage;
    private IInventoryItem currentItem; 
    private void Start()
    {
        Transform slotTransform = inventoryPanel.transform;
        currentItemImage = slotTransform.GetChild(0).GetComponent<Image>();

        colorInicial = currentItemImage.color;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { PressItem(0); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { PressItem(1); }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { PressItem(2); }
        if (Input.GetKeyDown(KeyCode.Alpha4)) { PressItem(3); }
        if (Input.GetKeyDown(KeyCode.Alpha5)) { PressItem(4); }
        if (Input.GetKeyDown(KeyCode.Alpha6)) { PressItem(5); }
    }

    private void PressItem(int slot)
    {
        if (slot < 0 || slot >= inventory.GetItems().Count)
            return;

        IInventoryItem item = inventory.GetItems()[slot];

        if (item != null)
        {

            if (currentItem != null)
            {
                GameObject currentItemObject = (currentItem as MonoBehaviour).gameObject;
                if (currentItemObject != null) 
                {
                    currentItemObject.SetActive(false);
                }
            }

            inventory.UseItem(item);

            currentItem = item;

            if (currentItemImage != null)
            {
                currentItemImage.color = colorInicial; 
            }

            Transform slotTransform = inventoryPanel.transform;
            currentItemImage = slotTransform.GetChild(slot).GetComponent<Image>();

            if (currentItemImage != null)
            {
                currentItemImage.color = Color.green; 
            }
        }
        else
        {
            Debug.LogWarning("Ítem nulo en el slot: " + slot); 
        }
    }
}
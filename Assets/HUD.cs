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
        // Suscribirse a los eventos de añadir y eliminar ítems
        Inventory.ItemAdded += InventoryScript_ItemAdded;
        Inventory.ItemRemoved += InventoryScript_ItemRemoved;  // Nuevo evento para la eliminación de ítems
    }

    // Manejo de la adición de un ítem
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

    // Manejo de la eliminación de un ítem
    public void InventoryScript_ItemRemoved(object sender, InventoryEventsArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel");

        foreach (Transform Slot in inventoryPanel)
        {
            Image image = Slot.GetChild(0).GetChild(0).GetComponent<Image>();

            // Verifica si la imagen actual corresponde al ítem eliminado
            if (image.sprite == e.Item.image)
            {
                image.enabled = false;
                image.sprite = null;  // Eliminar la imagen del slot
                break;
            }
        }
    }

    // Método para abrir el panel de mensajes
    public void OpenMessagePanel(string text)
    {
        MessagePanel.SetActive(true);
    }

    // Método para cerrar el panel de mensajes
    public void CloseMessagePanel()
    {
        MessagePanel.SetActive(false);
    }
}
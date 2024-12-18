using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class MovePlayer : MonoBehaviour
{
    public float velocidad = 8f;
    public float velocidadCorrer = 12f; 
    public Inventory inventory;
    public HUD hud;
    public QuestManager manager;

    private void Start()
    {
        inventory.ItemUsed += Inventory_ItemUsed;
    }

    private void Inventory_ItemUsed(object sender, InventoryEventsArgs e)
    {
        IInventoryItem item = e.Item;
        GameObject goItem = (item as MonoBehaviour).gameObject;

        if (goItem == null)
        {
            return;
        }

        goItem.SetActive(true);
        Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
        if (collider != null && collider.enabled == false)
        {
            collider.enabled = true;
        }

        goItem.transform.SetParent(transform);
        goItem.transform.localPosition = new Vector3(0, 0.2f, 1);
        goItem.transform.localRotation = Quaternion.identity;

        if (mItemToPickup == item)
        {
            mItemToPickup = null;
        }

        hud.CloseMessagePanel();
    }

    void Update()
    {
        if (mItemToPickup != null && Input.GetKeyDown(KeyCode.F))
        {
            inventory.addItem(mItemToPickup);

            mItemToPickup.OnPickUp();
            hud.CloseMessagePanel();

            Text questText = manager.Quest1.GetComponent<Text>();
            QuestManager managerQuest = manager.GetComponent<QuestManager>();

            if (questText != null && managerQuest.CantQuest == 0)
            {
                manager.CantQuest += 1;
                questText.color = Color.green;
            }

            mItemToPickup = null;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(horizontal, 0.0f, vertical);

        float velocidadActual = Input.GetKey(KeyCode.LeftShift) ? velocidadCorrer : velocidad;

        transform.Translate(movimiento * Time.deltaTime * velocidadActual);
    }

    private IInventoryItem mItemToPickup = null;

    private void OnTriggerEnter(Collider other)
    {
        IInventoryItem item = other.GetComponent<IInventoryItem>();

        if (item != null)
        {
            mItemToPickup = item;
            hud.OpenMessagePanel("");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IInventoryItem item = other.GetComponent<IInventoryItem>();

        if (item != null && mItemToPickup == item)
        {
            hud.CloseMessagePanel();
            mItemToPickup = null;
        }
    }
}
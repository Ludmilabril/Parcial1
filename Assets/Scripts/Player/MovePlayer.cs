using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class MovePlayer : MonoBehaviour
{
    public float velocidad = 8;
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
        if (collider.enabled == false)
        {
            collider.enabled = true;
        }

        goItem.transform.SetParent(transform); 
        goItem.transform.localPosition = new Vector3(0, 0.2f, 1);
        goItem.transform.localRotation = Quaternion.identity; 
    }
    void Update()
    {

        if (mItemToPickup != null && Input.GetKeyDown(KeyCode.F))
        {
            inventory.addItem(mItemToPickup);
            mItemToPickup.OnPickUp();
            hud.CloseMessagePanel();
            Text questText = manager.Quest1.GetComponent<Text>();

            if (questText != null)
            {
                manager.CantQuest += 1;
                questText.color = Color.green; 
            }
        }


        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(horizontal, 0.0f, vertical);
        transform.Translate(movimiento * Time.deltaTime * velocidad);
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

        if (item != null)
        {
            hud.CloseMessagePanel();
            mItemToPickup = null;
        }
    }
}
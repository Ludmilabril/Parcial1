using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using static UnityEditor.Progress;

public class MovePlayer : MonoBehaviour
{
    public float velocidad = 8;
    public Inventory inventory;


    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(horizontal, 0.0f, vertical);
        transform.Translate(movimiento * Time.deltaTime * velocidad);

    }
    private void OnTriggerEnter(Collider other)
    {
        IInventoryItem item = other.GetComponent<IInventoryItem>();
        if (other.CompareTag("Item"))
        {
            if (item != null)
            {
                inventory.addItem(item);
            }
        }
    }
}

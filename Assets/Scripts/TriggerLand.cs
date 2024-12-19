using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLand : MonoBehaviour
{
    public ManagersMoney money;
    public int PriceSell;
    public GameObject panel;
    public GameObject Fence;
    public GameObject panelNo;
    public GameObject trigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (money.CanAfford(PriceSell))
            {
                panel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else if (!money.CanAfford(PriceSell))
            {
                panelNo.SetActive(true);
            }

        }
     
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(false);
            panelNo.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        }
     
    }

    public void Si()
    {
        Fence.SetActive(false);
        money.removeMoney(PriceSell);
        Destroy(this.gameObject);
        panel.SetActive(false);

    }
    public void No()
    {
        panel.SetActive(false);
    }
}

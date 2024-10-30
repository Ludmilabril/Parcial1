using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pest : MonoBehaviour
{

    public GameObject PanelText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TomatosPesticide"))
        {
            Destroy(gameObject);  
            PanelText.SetActive(false);
        }
    }
}
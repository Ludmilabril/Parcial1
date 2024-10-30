using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pest : MonoBehaviour
{
    public string PesticideName;
    public GameObject PanelText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PesticideName))
        {
            Destroy(gameObject);  
            PanelText.SetActive(false);
        }
    }
}
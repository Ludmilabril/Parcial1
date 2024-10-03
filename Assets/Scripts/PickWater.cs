using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class PickWater : MonoBehaviour
{
    public GameObject pickWater;
    public bool Filled = false;
    public GameObject waterBucket;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WateringCan")) 
        {
            pickWater.SetActive(true);
            Filled = true;
            Renderer renderer = waterBucket.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = Color.blue; 
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("WateringCan"))
        {
            pickWater.SetActive(false);
        }
    }
}
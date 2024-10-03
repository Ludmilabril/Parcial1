using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PickWater : MonoBehaviour
{
    public GameObject pickWater;
    public bool Filled = false;
    public GameObject waterBucket;
    public QuestManager manager;


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
            Text questText = manager.Quest3.GetComponent<Text>();

            if (questText != null)
            {
                manager.CantQuest += 1;
                questText.color = Color.green;
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
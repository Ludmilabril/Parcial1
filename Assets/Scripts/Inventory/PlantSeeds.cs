using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantSeeds : MonoBehaviour
{
    public GameObject TextPlant;
    public GameObject TextTime;
    public GameObject TextRec;
    public TextMesh textMesh;
    public List<GameObject> fruits;
    public Inventory inventory;
    public string TypeSeed;

    private bool isInLandTrigger = false;
    private IInventoryItem currentSeedItem; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TypeSeed))
        {
            TextPlant.SetActive(true);
            isInLandTrigger = true;
            currentSeedItem = other.GetComponent<IInventoryItem>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(TypeSeed))
        {
            TextPlant.SetActive(false);
            TextTime.SetActive(false);
            textMesh.text = "";
            isInLandTrigger = false;
        }
    }

    private void Update()
    {
        if (isInLandTrigger && Input.GetKeyDown(KeyCode.Q))
        {
            TextPlant.SetActive(false);
            TextTime.SetActive(true);
            
            GameObject seedsObject = GameObject.FindGameObjectWithTag(TypeSeed);
            if (seedsObject != null)
            {
                seedsObject.SetActive(false);
            }
            if (currentSeedItem != null)
            {
                inventory.RemoveItem(currentSeedItem);
                currentSeedItem = null;
            }

            StartCoroutine(StartPlantingTimer(10f));
        
        }
       
    }

    private IEnumerator StartPlantingTimer(float duration)
    {
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;

            float remainingTime = duration - timer;
            textMesh.text = Mathf.Ceil(remainingTime).ToString();

            yield return null;
        }

        TextTime.SetActive(false);
        textMesh.text = "";
        TextRec.SetActive(true);

        ActivateFruits();

    }

    private void ActivateFruits()
    {
        foreach (GameObject fruit in fruits)
        {
            if (fruit != null)
            {
                fruit.SetActive(true);
                TextRec.SetActive(false);
            }
        }
    }
}
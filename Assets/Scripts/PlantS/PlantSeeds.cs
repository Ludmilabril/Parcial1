using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlantSeeds : MonoBehaviour
{
    public GameObject TextPlant;
    public GameObject TextPlant2;
    public GameObject TextTime;
    public GameObject TextRec;
    public TextMesh textMesh;
    public Inventory inventory;
    public string TypeSeed;
    public ControlWaterPlants waterControl;
    public QuestManager manager;
    public float timer;
    private bool isInLandTrigger = false;
    private IInventoryItem currentSeedItem;
    public QualitySliderManager qualitySliderManager;

    private bool WithGardenShovel = false;

    public SpawnPests spawnPests;  

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TypeSeed))
        {
            TextPlant.SetActive(true);
            isInLandTrigger = true;
            currentSeedItem = other.GetComponent<IInventoryItem>();
        }
        if (other.CompareTag("GardenShovel")) 
        {
            TextPlant2.SetActive(true);
            WithGardenShovel = true;
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
        if (other.CompareTag("GardenShovel"))
        {
            WithGardenShovel = false;
            TextPlant2.SetActive(false);
        }
        
    }

    private void Update()
    {
        if (isInLandTrigger && Input.GetKeyDown(KeyCode.Q))
        {
            TextPlant.SetActive(false);
          
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
           
        }
        if (WithGardenShovel && isInLandTrigger)
        {


            if (Input.GetKeyDown(KeyCode.Q))
            {
                TextPlant2.GetComponent<TextMesh>().text = "";
                TextTime.SetActive(true);

                waterControl.StartCoroutine(waterControl.WaterDecrease());
                StartCoroutine(StartPlantingTimer(timer));
                qualitySliderManager.ActivateSlider();
                Text questText = manager.Quest2.GetComponent<Text>();
                if (questText != null)
                {        
                    questText.color = Color.green;
                    manager.CantQuest += 1;
 
                }

            }
        }
    }

    private IEnumerator StartPlantingTimer(float duration)
    {
        float timer = 0f;

        
        spawnPests.StartSpawningPests(duration);
       
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
        waterControl.StopWaterDecrease();
        waterControl.ActivateFruits();
    }
}
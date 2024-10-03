using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControlWaterPlants : MonoBehaviour
{
    public float waterLevel = 100f;
    public float waterDecreaseRate = 1f;
    public List<GameObject> fruits;
    public PickWater pickWater;
    private bool canWater = false;
    public TextMesh waterText;
    public int WateringCanMax = 30;
    public GameObject waterBucket;
    public QuestManager manager;


    public IEnumerator WaterDecrease()
    {
        while (waterLevel > 0)
        {
            waterLevel -= waterDecreaseRate * Time.deltaTime;
            waterText.text = Mathf.FloorToInt(waterLevel).ToString();

            if (waterLevel <= 0)
            {
                waterLevel = 0;
                DeactivateFruits();
            }

            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WateringCan") && pickWater.Filled == true)
        {
            canWater = true;
            if ( waterLevel < 100f)
            {
                waterLevel += WateringCanMax;
                waterLevel = Mathf.Min(waterLevel, 100f);
                pickWater.Filled = false;
                Renderer renderer = waterBucket.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material.color = Color.white;
                }
                Text questText = manager.Quest4.GetComponent<Text>();

                if (questText != null)
                {
                    questText.color = Color.green;
                }


            }

            if (WateringCanMax <= 30)
            {
                pickWater.Filled = false;

            }


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("WateringCan"))
        {
            canWater = false;
        }
    }

    private void DeactivateFruits()
    {
        foreach (GameObject fruit in fruits)
        {
            if (fruit != null)
            {
                fruit.SetActive(false);
            }
        }
    }

    public void ActivateFruits()
    {
        foreach (GameObject fruit in fruits)
        {
            if (fruit != null)
            {
                fruit.SetActive(true);
            }
        }

        waterLevel = 100f;
    }
}
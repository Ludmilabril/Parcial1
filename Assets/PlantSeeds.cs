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

    private bool isInLandTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Seeds"))
        {
            TextPlant.SetActive(true);
            isInLandTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Seeds"))
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

            GameObject seedsObject = GameObject.FindGameObjectWithTag("Seeds");
            if (seedsObject != null)
            {
                seedsObject.SetActive(false);
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
            textMesh.text =  Mathf.Ceil(remainingTime).ToString(); 

            yield return null;
        }

        TextTime.SetActive(false);
        textMesh.text = "";
        TextRec.SetActive(true);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;
public class QualitySliderManager : MonoBehaviour
{
    public Slider qualitySlider;
    public Image fillArea;
    public ControlWaterPlants waterControl;
    public SpawnPests spawnPests;
    public float initialQuality = 50f;
    private float currentQuality;

    private void Start()
    {
        currentQuality = initialQuality;
        qualitySlider.gameObject.SetActive(false);
        qualitySlider.value = currentQuality / 100f;
        UpdateSliderColor();
    }

    private void Update()
    {
        if (qualitySlider.gameObject.activeSelf)
        {
            if (waterControl.waterLevel <= 30)
            {
                DecreaseQuality(1f * Time.deltaTime);
            }

            if (spawnPests.PanelText.activeSelf)
            {
                DecreaseQuality(0.5f * Time.deltaTime);
            }

            UpdateSliderColor();
            
        }
    }

    public void ActivateSlider()
    {
        qualitySlider.gameObject.SetActive(true);
    }

    public void IncreaseQuality(float amount)
    {
        currentQuality = Mathf.Min(100f, currentQuality + amount);
        qualitySlider.value = currentQuality / 100f;
        UpdateSliderColor();
    }

    private void DecreaseQuality(float amount)
    {
        currentQuality = Mathf.Max(0f, currentQuality - amount);
        qualitySlider.value = currentQuality / 100f;
        UpdateSliderColor();
    }
    public void stopSlider()
    {
        qualitySlider.value = currentQuality;
        IncreaseQuality(0);
        DecreaseQuality(0);
        UpdateSliderColor();
    }

    public void OnPestsEliminated()
    {
        IncreaseQuality(10f);
    }

    private void UpdateSliderColor()
    {
        if (currentQuality < 20f)
        {
            fillArea.color = Color.red;
        }
        else if (currentQuality >= 20f && currentQuality <= 50f)
        {
            fillArea.color = new Color(1f, 0.65f, 0f);
        }
        else
        {
            fillArea.color = Color.green;
        }
        GetCurrentQualityType();
    }

    public QualityType GetCurrentQualityType()
    {
        if (currentQuality < 20f)
            return QualityType.Low;
        else if (currentQuality >= 20f && currentQuality <= 50f)
            return QualityType.Medium;
        else
            return QualityType.High;
        
    }
}
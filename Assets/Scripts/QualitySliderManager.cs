using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        qualitySlider.gameObject.SetActive(false); // Desactiva el slider al inicio
        qualitySlider.value = currentQuality / 100f;
        UpdateSliderColor();
    }

    private void Update()
    {
        if (qualitySlider.gameObject.activeSelf) // Solo actualiza si el slider est� activo
        {
            if (waterControl.waterLevel <= 30)
            {
                DecreaseQuality(1f * Time.deltaTime);
            }

            if (spawnPests.PanelText.activeSelf)
            {
                DecreaseQuality(1f * Time.deltaTime);
            }

            UpdateSliderColor();
        }
    }

    // M�todo para activar el slider cuando se plantan las semillas
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

    public void OnPestsEliminated()
    {
        IncreaseQuality(5f);
    }

    private void UpdateSliderColor()
    {
        if (currentQuality < 20f)
        {
            fillArea.color = Color.red;
        }
        else if (currentQuality >= 20f && currentQuality < 50f)
        {
            fillArea.color = new Color(1f, 0.65f, 0f);
        }
        else
        {
            fillArea.color = Color.green;
        }
    }
}
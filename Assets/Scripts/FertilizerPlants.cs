using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FertilizerPlants : MonoBehaviour
{
    public string TypeFertilizer;
    public QualitySliderManager qualityManager; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TypeFertilizer))
        {
            if (qualityManager != null)
            {
                qualityManager.IncreaseQuality(20f);
            }
        }
    }
}
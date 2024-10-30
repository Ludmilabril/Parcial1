using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class HealthAndHunger : MonoBehaviour
{
    public Slider HealthBar;
    public Slider HungerBar;

    public float hunger;
    public float Health;


    public float LowHunger;
    public float LowHealth;
    public float ValueHungerToIncraseHealth;
    public float cantToIncraseHealthWithFood;
    public float SpeedSliders;

    private void Start()
    {
        RefreshValues();
    }
    public void RefreshValues()
    {
        if (hunger > 0 ) { RestHunger(LowHunger); }
        if (hunger > ValueHungerToIncraseHealth) { SumHealth(cantToIncraseHealthWithFood); }
        if (hunger == 0) { RestHealth(LowHealth); }
        if (hunger <= 0) { Debug.Log("You Die"); }

        hunger = math.clamp(hunger,0,100);
        Health = math.clamp(Health, 0, 100);
        RefreshSliders();
        Invoke("RefreshValues", SpeedSliders);
    }

  
    public void RefreshSliders()
    {
        HealthBar.value = Health;
        HungerBar.value = hunger;
    }
    public void SumHealth(float value)
    {
        Health += value;
    }
    public void RestHealth(float value)
    {
        Health -= value;
    }
    public void SumHunger(float value)
    {
        hunger += value;
    }
    public void RestHunger(float value)
    {
        hunger -= value;
    }

}

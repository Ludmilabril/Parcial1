using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ManagersMoney : MonoBehaviour
{
    public TextMeshProUGUI TextMoney; 
    private int currentMoney = 0;

    public void addMoney(int money)
    {
        currentMoney += money;
        UpdateMoneyUI();
    }

    public void removeMoney(int amount)
    {
        if (currentMoney >= amount)
        {
            currentMoney -= amount;
            UpdateMoneyUI();
        }
    }

    public bool CanAfford(int amount)
    {
        return currentMoney >= amount;
    }

    private void UpdateMoneyUI()
    {
        TextMoney.text = currentMoney.ToString();
    }
}
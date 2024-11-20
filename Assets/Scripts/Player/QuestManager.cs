using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;
public class QuestManager : MonoBehaviour
{
    public Text Quest1, Quest2, Quest3, Quest4, Quest5, Tut;
    public int CantQuest;
    public GameObject Closed, Panel;
    public int InitialMoney;
    public GameObject SeedPrefab;

    private ManagersMoney managersMoney;

    private void Start()
    {
        managersMoney = FindObjectOfType<ManagersMoney>();
        if (managersMoney == null)
        {
            Debug.LogError("ManagersMoney no encontrado. Por favor, asegúrate de que está en la escena.");
        }
    }

    private void Update()
    {
        if (CantQuest == 5)
        {
            Quest1.text = "Congratulations! You planted your first tomatoes.";
            Quest2.text = "Now you can buy more land and plant the rest from the store.";
            Quest3.text = Quest4.text = Quest5.text = Tut.text = "";

            Panel.SetActive(false);
            Closed.SetActive(false);
            SeedPrefab.SetActive(true);
            StartCoroutine(StartPlantingTimer(10f));
            if (managersMoney != null)
            {
                managersMoney.addMoney(InitialMoney);
                CantQuest = -100;
            }
        }
    }

    private IEnumerator StartPlantingTimer(float duration)
    {
        float timer = 0f;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        Quest1.text = "";
        Quest2.text = "";
    }
}
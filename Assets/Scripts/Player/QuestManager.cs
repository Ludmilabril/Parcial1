using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class QuestManager : MonoBehaviour
{
    public Text Quest1;
    public Text Quest2;
    public Text Quest3;
    public Text Quest4;
    public Text Quest5;
    public Text Tut;

    public int CantQuest;
    public GameObject Carrots;
    public GameObject Potatos;
    public GameObject Panel;
    private void Update()
    {
        if (CantQuest == 5)
        {
            Quest1.text = "Congratulatios you plant your first Tomatoes";
            Quest2.text = "Now you can plant the rest";
            Quest3.text = "";
            Quest4.text = "";
            Quest5.text = "";
            Tut.text = "";
            Panel.SetActive(false);
            Carrots.SetActive(true);
            Potatos.SetActive(true);
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


            yield return null;
        }

        Quest1.text = "";
        Quest2.text = "";
    }
}

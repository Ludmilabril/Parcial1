using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public Text Quest1;
    public Text Quest2;
    public Text Quest3;
    public Text Quest4;
    public Text Quest5;

    public int CantQuest;
    public GameObject Carrots;

    private void Update()
    {
        if (CantQuest == 5)
        {
            Quest1.text = "Congratulatios you plant your first Tomatoes";
            Quest2.text = "";
            Quest3.text = "";
            Quest4.text = "";
            Quest5.text = "";
            Carrots.SetActive(true);
        }
    }
}

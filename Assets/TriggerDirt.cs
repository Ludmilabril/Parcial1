using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerDirt : MonoBehaviour
{
    public bool Close = false;
    public bool Recolect = false;
    public bool Plant = false;
    public bool Seeds = false;
    public GameObject textRecolect;
    public GameObject textPlant;
    public GameObject Time;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Close = true;
            Time.SetActive(true);
            Debug.Log("Estas cerca");

            if (Recolect && Close)
            {
                textRecolect.SetActive(true);
                Time.SetActive(false);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Recolectaste");
                }
            }

            if (Plant && Close)
            {
                textPlant.SetActive(true);
                Time.SetActive(false);

                if (Input.GetKeyDown(KeyCode.Q) && Seeds)
                {
                    Debug.Log("Plantaste");
                }
            }
           
            

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Close = false;
            Time.SetActive(false);
            Debug.Log("Estas Afuera");
          
        }
    }
}

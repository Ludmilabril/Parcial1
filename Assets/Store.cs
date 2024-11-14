using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public GameObject storeCanvas; 
    public Button tomatoButton;
    public Button carrotButton;
    public Button potatoButton;
    public GameObject tomatoSeedPrefab;
    public GameObject carrotSeedPrefab;
    public GameObject potatoSeedPrefab;
    public Transform spawnPosition;
    public bool InStore;

    private void Start()
    {
        storeCanvas.SetActive(false);

        tomatoButton.onClick.AddListener(() => BuyItem(tomatoSeedPrefab));
        carrotButton.onClick.AddListener(() => BuyItem(carrotSeedPrefab));
        potatoButton.onClick.AddListener(() => BuyItem(potatoSeedPrefab));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InStore = true;
        }
        else { InStore = false;
        storeCanvas.SetActive(false);}
            
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InStore = false;
            storeCanvas.SetActive(false);
        }
   
    }
    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.E) && InStore == true)
        {
            storeCanvas.SetActive(!storeCanvas.activeSelf);
        }
    }

    private void BuyItem(GameObject itemPrefab)
    {
        if (itemPrefab != null && spawnPosition != null)
        {

            Instantiate(itemPrefab, spawnPosition.position, spawnPosition.rotation);

        }
    }
}
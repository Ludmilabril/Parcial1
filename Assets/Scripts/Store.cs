using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public GameObject storeCanvas;
    public Button tomatoButton;
    public Button carrotButton;
    public Button potatoButton;
    public Button TomatoLandButton;
    public Button CarrotLandButton;
    public Button PotatoLandButton;

    public GameObject tomatoSeedPrefab;
    public GameObject carrotSeedPrefab;
    public GameObject potatoSeedPrefab;
    public GameObject TomatoLandPrefab;
    public GameObject CarrotLandPrefab;
    public GameObject PotatoLandPrefab;

    public ItemPlacer itemPlacer; 
    private bool InStore;

    private void Start()
    {
        storeCanvas.SetActive(false);

        tomatoButton.onClick.AddListener(() => BuySeed(tomatoSeedPrefab));
        carrotButton.onClick.AddListener(() => BuySeed(carrotSeedPrefab));
        potatoButton.onClick.AddListener(() => BuySeed(potatoSeedPrefab));
        TomatoLandButton.onClick.AddListener(() => BuyLand("TomatoPlace", TomatoLandPrefab));
        CarrotLandButton.onClick.AddListener(() => BuyLand("CarrotPlace", CarrotLandPrefab));
        PotatoLandButton.onClick.AddListener(() => BuyLand("PotatoPlace", PotatoLandPrefab));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InStore = true;
        }
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
        if (Input.GetKeyDown(KeyCode.E) && InStore)
        {
            storeCanvas.SetActive(!storeCanvas.activeSelf);
        }
    }

    private void BuySeed(GameObject seedPrefab)
    {
        if (seedPrefab != null)
        {
            storeCanvas.SetActive(false);
        }
    }
    private void BuyLand(string placeTag, GameObject landPrefab)
    {
        if (landPrefab != null)
        {
            itemPlacer.ActivatePlacer(landPrefab, placeTag); 
            storeCanvas.SetActive(false);
        }
    }
}
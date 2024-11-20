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
    public ManagersMoney managersMoney;
    public Transform ItemTransform;

    private bool InStore;

    private const int seedPrice = 10;
    private const int landPrice = 20;

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
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && InStore)
        {
            storeCanvas.SetActive(!storeCanvas.activeSelf);
            Cursor.lockState = storeCanvas.activeSelf ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = storeCanvas.activeSelf;
        }
    }

    private void BuySeed(GameObject seedPrefab)
    {
        if (managersMoney != null && managersMoney.CanAfford(seedPrice))
        {
            managersMoney.removeMoney(seedPrice);

            GameObject newSeed = Instantiate(seedPrefab, ItemTransform.position, Quaternion.identity);

            Debug.Log("Seed purchased!");
            storeCanvas.SetActive(false);
        }
        else
        {
            Debug.Log("Not enough money to buy seeds!");
        }
    }

    private void BuyLand(string placeTag, GameObject landPrefab)
    {
        if (managersMoney != null && managersMoney.CanAfford(landPrice))
        {
            managersMoney.removeMoney(landPrice);
            itemPlacer.ActivatePlacer(landPrefab, placeTag);
            Debug.Log("Land purchased!");
            storeCanvas.SetActive(false);
        }
        else
        {
            Debug.Log("Not enough money to buy land!");
        }
    }
}
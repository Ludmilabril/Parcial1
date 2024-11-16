using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TerrainTools;
using UnityEngine.TerrainUtils;

public class ItemPlacer : MonoBehaviour
{
    public GameObject ghostPrefab;
    private GameObject ghostObject;
    private bool canPlace = false;
    private bool isActive = false;
    private bool isPlacing = false;

    private Camera mainCamera;
    private Terrain terrain;

    private string currentPlaceTag; 

    void Start()
    {
        ghostObject = Instantiate(ghostPrefab);
        ghostObject.SetActive(false);

        ghostObject.transform.localScale = new Vector3(11, 1f, 13);

        mainCamera = Camera.main;
        terrain = Terrain.activeTerrain;
    }

    void Update()
    {
        if (!isActive || ghostObject == null || !isPlacing)
        {
            return;
        }

        Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null && hit.collider.CompareTag(currentPlaceTag))
            {
                float terrainHeight = terrain.SampleHeight(hit.point);

                ghostObject.transform.position = new Vector3(hit.point.x, terrainHeight, hit.point.z);

                canPlace = true;
                ghostObject.GetComponent<Renderer>().material.color = canPlace ? Color.green : Color.red;
                ghostObject.SetActive(true);
            }
            else
            {
                canPlace = false;
                ghostObject.GetComponent<Renderer>().material.color = Color.red;
            }
        }

        if (Input.GetMouseButtonDown(0) && canPlace)
        {
            ghostObject.SetActive(false);
            isActive = false;
            isPlacing = false;

            if (hit.collider != null && hit.collider.CompareTag(currentPlaceTag))
            {
                Transform place = hit.collider.transform;
                foreach (Transform child in place)
                {
                    child.gameObject.SetActive(true);
                }
            }
        }
    }

    public void ActivatePlacer(GameObject newItemPrefab, string placeTag)
    {
        ghostObject.SetActive(true);
        isActive = true;
        isPlacing = true;
        currentPlaceTag = placeTag; 
    }

    public void CancelPlacing()
    {
        ghostObject.SetActive(false);
        isActive = false;
        isPlacing = false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnPests : MonoBehaviour
{
    public GameObject pestPrefab;       // Prefab de la plaga
    public Transform[] spawnPoints;     // Puntos de aparici�n de las plagas
    public float minSpawnInterval = 5f; // Intervalo m�nimo entre apariciones
    public float maxSpawnInterval = 10f; // Intervalo m�ximo entre apariciones

    private Coroutine spawnCoroutine;

    public GameObject PanelText;
    // Inicia el proceso de aparici�n de plagas
    public void StartSpawningPests(float duration)
    {
        spawnCoroutine = StartCoroutine(SpawnPestsRoutine(duration));
        
    }
    // M�todo que detiene la aparici�n de plagas
    public void StopSpawningPests()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
        }
    }

    private IEnumerator SpawnPestsRoutine(float duration)
    {
        float timer = 0f;

        while (timer < duration)
        {
            // Espera un tiempo aleatorio antes de la siguiente aparici�n
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(spawnInterval);

            // Aparece una plaga en un punto aleatorio
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(pestPrefab, spawnPoint.position, Quaternion.identity);

            timer += spawnInterval;
            PanelText.SetActive(true);
        }
    }
}
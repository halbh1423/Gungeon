using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform target;
    [Header("Spawn Radius")]
    public float spawnRadius = 30f;
    public float initialSpawnInterval = 5f;
    public float minSpawnInterval = 2f;
    public float intervalDecreaseRate = 1f;
    public float minSpawnDistance = 10f;

    private float currentSpawnInterval;

    void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
        StartCoroutine(SpawnEnemies());
        StartCoroutine(DecreaseSpawnInterval());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(currentSpawnInterval);
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                target = player.transform;
                Vector3 spawnPosition;
                do
                {
                    spawnPosition = target.position + (Vector3)(Random.insideUnitCircle * spawnRadius);
                } while (Vector3.Distance(spawnPosition, target.position) < minSpawnDistance);

                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }

    IEnumerator DecreaseSpawnInterval()
    {
        while (currentSpawnInterval > minSpawnInterval)
        {
            yield return new WaitForSeconds(30f); 
            currentSpawnInterval = Mathf.Max(currentSpawnInterval - intervalDecreaseRate, minSpawnInterval);
        }
    }
}

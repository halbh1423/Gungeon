using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalEnemySpawn : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform spawnPoint;
    public float initialSpawnInterval = 5f;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(initialSpawnInterval);
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}

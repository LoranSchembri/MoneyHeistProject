using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
    {
    public GameObject enemyPrefab; // Assign in inspector
    public string spawnPointTag = "SpawnPoint"; // Tag for spawn points
    private List<Transform> spawnPoints;
    public float spawnInterval = 5f; // Time between each spawn

    private float timeSinceLastSpawn;

    private void Start()
        {
        timeSinceLastSpawn = spawnInterval;

        // Find all GameObjects with the spawnPointTag and add to spawnPoints list
        spawnPoints = new List<Transform>();
        foreach (var spawnPoint in GameObject.FindGameObjectsWithTag(spawnPointTag))
            {
            spawnPoints.Add(spawnPoint.transform);
            }
        }

    private void Update()
        {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval && spawnPoints.Count > 0)
            {
            SpawnEnemy();
            timeSinceLastSpawn = 0;
            }
        }

    void SpawnEnemy()
        {
        int spawnIndex = Random.Range(0, spawnPoints.Count);
        Instantiate(enemyPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);
        spawnPoints.RemoveAt(spawnIndex); // Remove the used spawn point
        }
    }

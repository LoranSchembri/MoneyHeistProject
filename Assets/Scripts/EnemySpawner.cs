using UnityEngine;

public class EnemySpawner : MonoBehaviour
    {
    public GameObject enemyPrefab; // Assign in inspector
    public Transform[] spawnPoints; // Assign in inspector
    public float spawnInterval = 5f; // Time between each spawn

    private float timeSinceLastSpawn;

    private void Start()
        {
        timeSinceLastSpawn = spawnInterval;
        }

    private void Update()
        {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
            {
            SpawnEnemy();
            timeSinceLastSpawn = 0;
            }
        }

    void SpawnEnemy()
        {
        if (spawnPoints.Length == 0) return;

        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);
        }
    }

using UnityEngine;
using System.Collections;

public class Level3EnemySpawner : MonoBehaviour
{
<<<<<<< Updated upstream
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public Transform helicopter;
    public float spawnInterval = 5.0f;
    public int specificSpawnPointIndex = 0;
<<<<<<< HEAD
=======
    public GameObject enemyPrefab; // Assign your enemy prefab in the Inspector
    public Transform[] spawnPoints; // Assign spawn points in the Inspector
    public Transform helicopter; // Assign the helicopter transform in the Inspector
    public float spawnInterval = 5.0f; // Time in seconds between spawns
    public int specificSpawnPointIndex = 0; // Index of the spawn point that spawns enemies periodically
>>>>>>> Stashed changes
=======
    public Transform[] surroundPoints; // Points around the helicopter
    private int nextPointIndex = 0; // To cycle through surround points
>>>>>>> parent of a800586 (stuff)

    void Start()
    {
        // Spawn an enemy at each spawn point once at the start
        foreach (Transform spawnPoint in spawnPoints)
        {
            SpawnEnemy(spawnPoint);
        }

        // Start the coroutine for timed spawning at a specific spawn point
        if (spawnPoints.Length > specificSpawnPointIndex)
        {
            StartCoroutine(TimedSpawn(spawnPoints[specificSpawnPointIndex]));
        }
    }

    void SpawnEnemy(Transform spawnPoint)
    {
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        Level3EnemyController enemyController = newEnemy.GetComponent<Level3EnemyController>();
        if (enemyController != null)
        {
<<<<<<< Updated upstream
            enemyController.helicopter = helicopter;
<<<<<<< HEAD
=======
            enemyController.helicopter = helicopter; // Assign the helicopter reference
>>>>>>> Stashed changes
=======
            enemyController.SetTarget(surroundPoints[nextPointIndex].position); // Direct to a surround point
            nextPointIndex = (nextPointIndex + 1) % surroundPoints.Length; // Cycle through points
>>>>>>> parent of a800586 (stuff)
        }
    }

    IEnumerator TimedSpawn(Transform spawnPoint)
    {
        while (true) // Infinite loop, can be modified to stop based on a condition
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnEnemy(spawnPoint);
        }
    }
}
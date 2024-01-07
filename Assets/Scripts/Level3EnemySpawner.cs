using UnityEngine;
using System.Collections;

public class Level3EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public Transform helicopter;
    public float spawnInterval = 5.0f;
    public int specificSpawnPointIndex = 0;
    public Transform[] surroundPoints; // Points around the helicopter
    private int nextPointIndex = 0; // To cycle through surround points

    void Start()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            SpawnEnemy(spawnPoint);
        }

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
            enemyController.helicopter = helicopter;
            enemyController.SetTarget(surroundPoints[nextPointIndex].position); // Direct to a surround point
            nextPointIndex = (nextPointIndex + 1) % surroundPoints.Length; // Cycle through points
        }
    }

    IEnumerator TimedSpawn(Transform spawnPoint)
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnEnemy(spawnPoint);
        }
    }
}

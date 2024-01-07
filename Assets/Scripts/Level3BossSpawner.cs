using UnityEngine;
using System.Collections;

public class Level3BossSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public Transform helicopter;
    public int specificSpawnPointIndex = 0;

    void Start()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            SpawnEnemy(spawnPoint);
        }
    }

    void SpawnEnemy(Transform spawnPoint)
    {
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        Level3EnemyController enemyController = newEnemy.GetComponent<Level3EnemyController>();
        if (enemyController != null)
        {
            enemyController.helicopter = helicopter;
        }
    }
}

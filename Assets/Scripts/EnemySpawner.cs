using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Assign in inspector
    public GameObject bossPrefab;
    public string bossSpawnPointTag = "BossSpawnPoint";
    public string spawnPointTag = "SpawnPoint"; // Tag for spawn points
    private Transform bossSpawnPoint;
    private Transform[] spawnPoints;
    private bool spawned = false; // Flag to control spawning

    private void Start()
    {
        // Find the boss spawn point
        GameObject bossSpawnPointObject = GameObject.FindGameObjectWithTag(bossSpawnPointTag);
        if (bossSpawnPointObject != null)
        {
            bossSpawnPoint = bossSpawnPointObject.transform;
        }

        // Find all GameObjects with the spawnPointTag and add to spawnPoints array
        GameObject[] spawnPointObjects = GameObject.FindGameObjectsWithTag(spawnPointTag);
        spawnPoints = new Transform[spawnPointObjects.Length];
        for (int i = 0; i < spawnPointObjects.Length; i++)
        {
            spawnPoints[i] = spawnPointObjects[i].transform;
        }

        SpawnAllEnemies(); // Spawn enemies and boss once at start
    }

    void SpawnAllEnemies()
    {
        if (!spawned) // Check if the enemies have not been spawned yet
        {
            // Spawn the boss if the boss spawn point exists
            if (bossSpawnPoint != null)
            {
                Instantiate(bossPrefab, bossSpawnPoint.position, Quaternion.identity);
            }

            // Spawn normal enemies at each spawn point
            foreach (var spawnPoint in spawnPoints)
            {
                Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            }

            spawned = true; // Set the flag to prevent further spawning
        }
    }
}

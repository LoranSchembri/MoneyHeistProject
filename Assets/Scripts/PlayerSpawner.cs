using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab; // Drag your player prefab here in the inspector
    [SerializeField] private Transform spawnPoint; // Set a spawn point in the inspector

    private bool hasSpawned = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Car"))
        {
            hasSpawned = true;
            StartCoroutine(SpawnAfterDelay(1f));
        }
    }

    private IEnumerator SpawnAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Waits for the specified delay
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        Destroy(gameObject); // Destroys the barrier to prevent further collisions
    }
}


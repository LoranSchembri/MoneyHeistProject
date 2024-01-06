using UnityEngine;
using System.Collections; // Explicitly include System.Collections

public class SceneLoader : MonoBehaviour
    {
    public GameObject playerPrefab; // Assign the player prefab in the inspector
    public Transform spawnPoint;    // Assign the spawn point in the inspector

    void Start()
        {
        StartCoroutine(SpawnPlayerAfterDelay(7f)); // Wait for 7 seconds before spawning the player
        }

    IEnumerator SpawnPlayerAfterDelay(float delay)
        {
        yield return new WaitForSeconds(delay);
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

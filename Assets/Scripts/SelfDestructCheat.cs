using UnityEngine;

public class SelfDestructCheat : MonoBehaviour
    {
    public GameObject playerPrefab; // Assign the player prefab in the inspector
    public Transform spawnPoint;    // Assign the spawn point in the inspector

    void Update()
        {
        if (Input.GetKeyDown(KeyCode.K))
            {
            RespawnPlayer();
            }
        }

    private void RespawnPlayer()
        {
        // Find the current player by tag
        GameObject currentPlayer = GameObject.FindGameObjectWithTag("Player");

        // Destroy the current player, if it exists
        if (currentPlayer != null)
            {
            Destroy(currentPlayer);
            }

        // Spawn a new player instance
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

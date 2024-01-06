using UnityEngine;

public class PlayerRespawner : MonoBehaviour
    {
    public GameObject playerPrefab; // Assign the player prefab in the inspector
    public Transform spawnPoint;    // Assign the spawn point in the inspector
    private GameObject currentPlayer;

    void Update()
        {
        if (Input.GetKeyDown(KeyCode.K))
            {
            RespawnPlayer();
            }
        }

    void RespawnPlayer()
        {
        // Destroy the current player, if it exists
        if (currentPlayer != null)
            {
            Destroy(currentPlayer);
            }

        // Spawn a new player instance
        currentPlayer = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

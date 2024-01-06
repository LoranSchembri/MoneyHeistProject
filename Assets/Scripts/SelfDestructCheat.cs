using UnityEngine;

public class SelfDestructCheat : MonoBehaviour
    {
    public GameObject playerPrefab; // Assign the player prefab in the inspector
    public Transform spawnPoint;    // Assign the spawn point in the inspector

    private GameObject currentPlayer;

    void Start()
        {
        // Find the existing player instance in the scene
        currentPlayer = GameObject.FindGameObjectWithTag("Player");
        }

    void Update()
        {
        if (Input.GetKeyDown(KeyCode.K))
            {
            RespawnPlayer();
            }
        }

    private void RespawnPlayer()
        {
        // Destroy the current player, if it exists
        if (currentPlayer != null)
            {
            Destroy(currentPlayer);
            }

        // Spawn a new player instance
        currentPlayer = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        currentPlayer.tag = "Player"; // Ensure the new player has the "Player" tag
        }
    }

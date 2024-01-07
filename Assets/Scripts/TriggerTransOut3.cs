using UnityEngine;
using UnityEngine.SceneManagement; // Required for loading scenes
using Cinemachine;
using System.Collections;

public class TriggerTransOut3 : MonoBehaviour
    {
    public CinemachineVirtualCamera TransitionOutCamera; // Assign in Inspector
    public GameObject respawnPoint; // Assign the respawn point GameObject in Inspector
    public float respawnDelay = 5f; // Delay before respawning the player
    public string nextSceneName = "Level3Helicopter"; // Name of the scene to load

    private void OnTriggerEnter(Collider other)
        {
        if (other.CompareTag("Player"))
            {
            if (TransitionOutCamera != null)
                {
                TransitionOutCamera.Priority = 11; // Ensure this camera takes over
                }

            StartCoroutine(RespawnPlayer(other.gameObject));
            }
        }

    private IEnumerator RespawnPlayer(GameObject player)
        {
        // Deactivate the player instead of destroying
        player.SetActive(false);

        // Wait for the respawn delay
        yield return new WaitForSeconds(respawnDelay);

        // Reactivate the player at the respawn point position
        player.transform.position = respawnPoint.transform.position;
        player.SetActive(true);

        // Load the next scene
        SceneManager.LoadScene(nextSceneName);
        }
    }

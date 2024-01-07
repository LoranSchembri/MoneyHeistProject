using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FloorCinematicTrigger : MonoBehaviour
    {
    public CinemachineVirtualCamera dollyCamera; // Assign in inspector

    void Start()
        {
        if (dollyCamera != null)
            {
            // Set initial priority lower than the main camera
            dollyCamera.Priority = 9;
            }
        }

    private void OnTriggerEnter(Collider other)
        {
        if (other.CompareTag("Player")) // Make sure the player has the tag "Player"
            {
            StartCinematic();
            }
        }

    private void StartCinematic()
        {
        if (dollyCamera != null)
            {
            // Increase priority to take over
            dollyCamera.Priority = 11;
            StartCoroutine(ChangeSceneAfterDelay(6f)); // Wait 6 seconds before changing the scene
            }
        else
            {
            Debug.LogError("Dolly Camera not assigned.");
            }
        }

    private IEnumerator ChangeSceneAfterDelay(float delay)
        {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Level3Helicopter"); // Change to your desired scene name
        }
    }

using UnityEngine;
using Cinemachine;
using System.Collections;

public class FloorCinematicTrigger : MonoBehaviour
    {
    public CinemachineVirtualCamera dollyCamera; // Assign in inspector
    private int mainCameraPriority = 10; // Assuming main camera's priority is 10

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
            dollyCamera.Priority = 11; // Higher priority to take over
            StartCoroutine(ReturnToMainCameraAfterDelay(5f)); // Wait 5 seconds before returning to main camera
            }
        else
            {
            Debug.LogError("Dolly Camera not assigned.");
            }
        }

    private IEnumerator ReturnToMainCameraAfterDelay(float delay)
        {
        yield return new WaitForSeconds(delay);
        if (dollyCamera != null)
            {
            dollyCamera.Priority = mainCameraPriority - 1; // Lower priority to return to main camera
            }
        }
    }

using UnityEngine;
using Cinemachine;

public class TriggerTransOut3 : MonoBehaviour
    {
    public CinemachineVirtualCamera TransitionOutCamera; // Assign in Inspector

    private void OnTriggerEnter(Collider other)
        {
        if (other.CompareTag("Player"))
            {
            if (TransitionOutCamera != null)
                {
                TransitionOutCamera.Priority = 11; // Ensure this is higher than the main camera's priority
                }

            Destroy(other.gameObject); // Destroy the player object
            }
        }
    }
using UnityEngine;
using Cinemachine;
using System.Collections;

public class TriggerTransOut3 : MonoBehaviour
    {
    public CinemachineVirtualCamera TransitionOutCamera; // Assign in Inspector
    private int mainCameraPriority = 10; // Assuming main camera's priority is 10
    public float transitionDuration = 5f; // Duration for which the transition camera is active

    private void OnTriggerEnter(Collider other)
        {
        if (other.CompareTag("Player"))
            {
            if (TransitionOutCamera != null)
                {
                TransitionOutCamera.Priority = 11; // Ensure this camera takes over
                StartCoroutine(ReturnToMainCameraAfterDelay(transitionDuration));
                }
            else
                {
                Debug.LogError("Transition Out Camera not assigned.");
                }
            }
        }

    private IEnumerator ReturnToMainCameraAfterDelay(float delay)
        {
        yield return new WaitForSeconds(delay);
        if (TransitionOutCamera != null)
            {
            TransitionOutCamera.Priority = mainCameraPriority - 1; // Lower priority to return to main camera
            }
        }
    }

using UnityEngine;
using Cinemachine;

public class HelicopterCollision : MonoBehaviour
{
    public CinemachineVirtualCamera helicopterCamera; // Assign in Inspector
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger("FlyAway");

            if (helicopterCamera != null)
            {
                helicopterCamera.Priority = 11; // Ensure this is higher than the main camera's priority
            }

            Destroy(other.gameObject); // Destroy the player object
        }
    }
}

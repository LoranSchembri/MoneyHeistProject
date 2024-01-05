using UnityEngine;

public class DoorOpener : MonoBehaviour
    {
    public Transform door; // Assign the door transform in the inspector
    private bool isOpening = false;
    private float targetYRotation = 651.0f % 360; // Normalize rotation to a value between 0-360
    private float rotationSpeed = 2.0f; // Adjust the speed as needed

    private void Update()
        {
        if (isOpening)
            {
            Quaternion targetRotation = Quaternion.Euler(0, targetYRotation, 0);
            door.rotation = Quaternion.Lerp(door.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            // Optional: Add a condition to stop rotating once the door reaches the target rotation
            if (Quaternion.Angle(door.rotation, targetRotation) < 0.5f)
                {
                isOpening = false;
                }
            }
        }

    private void OnTriggerEnter(Collider other)
        {
        // Replace "Player" with the appropriate tag, if needed
        if (other.CompareTag("Player"))
            {
            isOpening = true;
            }
        }
    }

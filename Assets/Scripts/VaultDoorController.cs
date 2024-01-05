using UnityEngine;

public class VaultDoorController : MonoBehaviour
    {
    public Transform door; // Assign the door transform in the inspector
    public Transform handle; // Assign the handle transform in the inspector
    private bool isOpening = false;
    private bool isHandleRotated = false;
    private float doorTargetYRotation = 152.0f;
    private float handleTargetZRotation = -358.0f;
    private float rotationSpeed = 1.0f; // Adjust the speed as needed

    private void OnTriggerEnter(Collider other)
        {
        if (other.CompareTag("Player")) // Make sure the player has a tag "Player"
            {
            isOpening = true;
            }
        }

    // Removed OnTriggerExit method

    private void Update()
        {
        if (isOpening && !isHandleRotated)
            {
            // Rotate the handle on Z-axis
            Quaternion targetHandleRotation = Quaternion.Euler(0, handleTargetZRotation, 0);
            handle.rotation = Quaternion.Lerp(handle.rotation, targetHandleRotation, Time.deltaTime * rotationSpeed);

            // Check if the handle has reached the target rotation
            if (Quaternion.Angle(handle.rotation, targetHandleRotation) < 0.5f)
                {
                isHandleRotated = true;
                }
            }
        else if (isOpening && isHandleRotated)
            {
            // Rotate the door on Y-axis
            Quaternion targetDoorRotation = Quaternion.Euler(0, doorTargetYRotation, 0);
            door.rotation = Quaternion.Lerp(door.rotation, targetDoorRotation, Time.deltaTime * rotationSpeed);
            }
        }
    }

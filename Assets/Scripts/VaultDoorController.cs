using UnityEngine;

public class VaultDoorController : MonoBehaviour
    {
    public Transform door; // Assign in inspector
    public Transform handle; // Assign in inspector

    private bool isOpening = false;
    private bool isHandleRotated = false;
    private float doorTargetYRotation = 152.0f;
    private float handleTargetZRotation = -358.0f;
    private float rotationSpeed = 2f; // Increased rotation speed

    private void OnTriggerEnter(Collider other)
        {
        if (other.CompareTag("Player"))
            {
            isOpening = true;
            }
        }

    private void Update()
        {
        if (isOpening && !isHandleRotated)
            {
            Quaternion targetHandleRotation = Quaternion.Euler(0, 0, handleTargetZRotation);
            handle.rotation = Quaternion.RotateTowards(handle.rotation, targetHandleRotation, Time.deltaTime * rotationSpeed);

            Debug.Log("Rotating Handle"); // Add this line for debugging

            if (Quaternion.Angle(handle.rotation, targetHandleRotation) < 1.0f)
                {
                isHandleRotated = true;
                Debug.Log("Handle Rotated"); // Debugging
                }
            }
        else if (isOpening && isHandleRotated)
            {
            Quaternion targetDoorRotation = Quaternion.Euler(0, doorTargetYRotation, 0);
            door.rotation = Quaternion.Lerp(door.rotation, targetDoorRotation, Time.deltaTime * rotationSpeed);
            }
        }
    }
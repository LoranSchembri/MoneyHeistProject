using UnityEngine;

public class MainBankDoor : MonoBehaviour
    {
    public Transform door1; // Assign the first door transform in the inspector
    public Transform door2; // Assign the second door transform in the inspector

    private bool door1IsOpening = false;
    private bool door2IsOpening = false;

    private float door1TargetYRotation = 116.409f;
    private float door2TargetYRotation = -116.409f;

    private float rotationSpeed = 1.0f; // Adjust the speed as needed

    private void OnTriggerEnter(Collider other)
        {
        if (other.CompareTag("Player")) // Make sure the player has a tag "Player"
            {
            door1IsOpening = true;
            door2IsOpening = true;
            }
        }

    private void Update()
        {
        if (door1IsOpening)
            {
            RotateDoor(door1, door1TargetYRotation);
            }

        if (door2IsOpening)
            {
            RotateDoor(door2, door2TargetYRotation);
            }
        }

    private void RotateDoor(Transform door, float targetYRotation)
        {
        Quaternion targetRotation = Quaternion.Euler(0, targetYRotation, 0);
        door.rotation = Quaternion.Lerp(door.rotation, targetRotation, Time.deltaTime * rotationSpeed);

        // Optional: Add a condition to stop rotating once the door reaches the target rotation
        if (Quaternion.Angle(door.rotation, targetRotation) < 0.5f)
            {
            if (door == door1) door1IsOpening = false;
            if (door == door2) door2IsOpening = false;
            }
        }
    }

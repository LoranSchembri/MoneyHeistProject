using UnityEngine;

public class Rotator : MonoBehaviour
    {
    public float rotationSpeed = 50.0f; // Rotation speed in degrees per second
    private bool shouldRotate = false;

    public void StartRotation()
        {
        shouldRotate = true;
        }

    private void Update()
        {
        if (shouldRotate)
            {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
            }
        }
    }

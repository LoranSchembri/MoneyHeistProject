using UnityEngine;

public class TouchDetector : MonoBehaviour
    {
    public Rotator rotator; // Assign this in the inspector

    private void OnTriggerEnter(Collider other)
        {
        print("collision");
        if (other.gameObject.CompareTag("Player")) // Replace "Player" with the tag of the touching object
            {
            print("collision 2");
            rotator.StartRotation();
            }
        }
    }

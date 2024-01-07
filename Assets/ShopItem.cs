using UnityEngine;

public class ShopItem : MonoBehaviour
    {
    public string itemName;
    public int quantity;
    public GameObject itemPrefab;
    public GameObject shopCanvas; // Assign your shop canvas in the inspector

    private void OnTriggerEnter(Collider other)
        {
        if (other.CompareTag("Player")) // Check if the player entered the trigger
            {
            shopCanvas.SetActive(true); // Open the shop GUI
            }
        }

    private void OnTriggerExit(Collider other)
        {
        if (other.CompareTag("Player")) // Check if the player left the trigger
            {
            shopCanvas.SetActive(false); // Close the shop GUI
            }
        }
    }

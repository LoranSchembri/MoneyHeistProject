using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class ShopItem
    {
    public string itemName;
    public int quantity;
    public GameObject itemPrefab; // Reference to the item prefab
    }

public class ShopManager : MonoBehaviour
    {
    public ShopItem[] items; // Array to hold your shop items
    public GameObject[] itemButtons; // Buttons in this panel
    public TextMeshProUGUI[] itemNameTexts; // Item name texts in this panel
    public TextMeshProUGUI[] itemQuantityTexts; // Item quantity texts in this panel

    void Start()
        {
        InitializePanelItems();
        }

    void InitializePanelItems()
        {
        for (int i = 0; i < items.Length; i++)
            {
            if (i < itemButtons.Length && i < itemNameTexts.Length && i < itemQuantityTexts.Length)
                {
                itemNameTexts[i].text = items[i].itemName;
                itemQuantityTexts[i].text = "Quantity: " + items[i].quantity.ToString();

                int itemIndex = i; // Local copy for the closure in the listener
                Button btn = itemButtons[i].GetComponent<Button>();
                if (btn != null)
                    {
                    btn.onClick.AddListener(() => PurchaseItem(itemIndex));
                    }
                }
            }
        }

    public void PurchaseItem(int itemIndex)
        {
        if (itemIndex < 0 || itemIndex >= items.Length)
            {
            Debug.LogError("Item index out of range");
            return;
            }

        if (items[itemIndex].quantity > 0)
            {
            items[itemIndex].quantity--; // Reduce the quantity
            itemQuantityTexts[itemIndex].text = "Quantity: " + items[itemIndex].quantity.ToString();

            // Here, you can add more code to handle what happens when an item is purchased
            // For example, adding the item to the player's inventory
            }
        else
            {
            Debug.Log("Item out of stock");
            }
        }
    }

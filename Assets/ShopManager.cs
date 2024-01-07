using UnityEngine;
using UnityEngine.UI;
using TMPro; // Make sure you have TextMeshPro in your project

public class ShopManager : MonoBehaviour
    {
    public ShopItem[] items; // Items for this specific panel

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
                // Additional initialization as needed
                }
            }
        }
    }
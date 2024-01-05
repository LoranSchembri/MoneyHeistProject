using UnityEngine;
using TMPro; // TextMeshPro namespace

public class UIManager : MonoBehaviour
    {
    public StealingMechanism stealingMechanism; // Assign in inspector
    public TextMeshProUGUI robPercentageText; // For TextMeshPro

    void Update()
        {
        if (stealingMechanism != null)
            {
            float stealingProgress = stealingMechanism.GetStealingProgress();
            robPercentageText.text = $"Stealing: {stealingProgress:F2}%";
            }
        }
    }

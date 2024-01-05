using UnityEngine;

public class PlayerHealth : MonoBehaviour
    {
    public int health = 100;

    public void TakeDamage(int damageAmount)
        {
        health -= damageAmount;
        if (health <= 0)
            {
            Debug.Log("Player is Dead!");
            // Implement player death (disable movement, show death screen, etc.)
            }
        }
    }

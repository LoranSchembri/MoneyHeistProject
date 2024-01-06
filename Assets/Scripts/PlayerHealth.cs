using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;
    public GameObject respawnPoint;

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Debug.Log("Player is Dead!");
        // Implement player death (disable movement, show death screen, etc.)
        gameObject.SetActive(false); // Deactivates the player GameObject
        // Here, you can add additional death logic such as animations, sounds, etc.
    }

    public void Revive()
    {
        // Set the player's position to the respawn point
        transform.position = respawnPoint.transform.position;

        // Reset health to max
        this.health = maxHealth;

        // Reactivate the player GameObject
        gameObject.SetActive(true);
    }
}

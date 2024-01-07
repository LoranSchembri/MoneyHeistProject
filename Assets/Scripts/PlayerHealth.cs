using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;

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
        Destroy(gameObject); // Destroys the player object
    }

    public void Revive()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        Vector3 respawnPosition;
        Quaternion respawnRotation;

        
        if (currentScene == "Level1Park")
        {
            respawnPosition = new Vector3(-40, 1.5f, 98);
            respawnRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (currentScene == "Level2Bank")
        {
            respawnPosition = new Vector3(-2.271f, 1.5f, 16.054f);
            respawnRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (currentScene == "Level3Helicopter")
        {
            
            respawnPosition = new Vector3(2f, 2f, 2f); 
            respawnRotation = Quaternion.Euler(0,180,0); 
        }
        else
        {
            
            respawnPosition = Vector3.zero; // Or any default position
            respawnRotation = Quaternion.identity;
        }

        
        Instantiate(gameObject, respawnPosition, respawnRotation);

        // Reset health to max
        health = maxHealth;
    }
}

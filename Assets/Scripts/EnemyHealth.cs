using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int regularEnemyHealth = 200;
    public int bossHealth = 1200;
    public GameObject bloodImpactPrefab; // Reference to the blood impact prefab

    private int currentHealth;
    private Animator animator;

    void Start()
    {
        // Initialize the animator
        animator = GetComponent<Animator>();

        // Set health based on whether this is a boss or a regular enemy
        if (gameObject.CompareTag("Boss"))
        {
            currentHealth = bossHealth;
        }
        else if (gameObject.CompareTag("Enemy"))
        {
            currentHealth = regularEnemyHealth;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the Bullet tag
        if (other.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(40); // Bullet does 40 damage
            SpawnBloodEffect(other.transform.position); // Spawn blood effect at the collision point
            Destroy(other.gameObject); // Optionally destroy the bullet on impact
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Check if the enemy is dead
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public static void KillAll()
    {
        EnemyHealth[] allEnemies = FindObjectsOfType<EnemyHealth>();
        foreach (EnemyHealth enemy in allEnemies)
        {
            enemy.Die();
        }
    }

    void Die()
    {
        // Play death animation
        //animator.SetTrigger("Die");

        // Disable the enemy component or destroy the game object
        // For example:
         Destroy(gameObject);
        // or
        // this.enabled = false;
    }

    void SpawnBloodEffect(Vector3 position)
    {
        // Instantiate the blood impact prefab at the collision point
        if (bloodImpactPrefab != null)
        {
            Instantiate(bloodImpactPrefab, position, Quaternion.identity);
        }
    }
}

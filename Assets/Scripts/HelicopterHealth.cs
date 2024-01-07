using UnityEngine;

public class HelicopterHealth : MonoBehaviour
{
    public float health = 100f; // Starting health

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Destroy(gameObject); // Destroy helicopter when health is depleted
        }
    }
}

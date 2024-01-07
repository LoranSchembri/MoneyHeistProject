using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;
    public GameObject respawnPoint;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            StartCoroutine(RespawnPlayer());
        }
    }

    private IEnumerator RespawnPlayer()
    {
        Debug.Log("Player is Dead!");
        gameObject.SetActive(false); 
        
        yield return new WaitForSeconds(2);

        Debug.Log("Respawning Player");
        Revive();
    }

    public void Revive()
    {
        
        transform.position = respawnPoint.transform.position;

        
        this.health = maxHealth;

        
        gameObject.SetActive(true);
    }
}

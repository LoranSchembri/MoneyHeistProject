using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneLevel2Bank : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object is the player
        if (collision.gameObject.tag == "Player")
        {
            // Load the Level2Bank scene
            SceneManager.LoadScene("Level2Bank");
        }
    }
}

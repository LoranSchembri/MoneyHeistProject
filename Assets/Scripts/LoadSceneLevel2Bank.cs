using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneLevel2Bank : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Load");
            // Load the Level2Bank scene
            SceneManager.LoadScene("Level2Bank");
        }
    }
}

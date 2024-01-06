using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheat : MonoBehaviour
    {
    void Update()
        {
        if (Input.GetKeyDown(KeyCode.K))
            {
            HandleCheatCode();
            }
        }

    void HandleCheatCode()
        {
        string currentScene = SceneManager.GetActiveScene().name;

        switch (currentScene)
            {
            case "Level1Park":
                EnemyHealth.KillAll();
                break;
            case "Level2Bank":
                SelfDestructCheat.RespawnPlayer();

                break;
            case "Level3Helicopter":

                break;
            }
        }

    }

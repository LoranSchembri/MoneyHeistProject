using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab; // Assign your player prefab in the Inspector

    void Start()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.Euler(0, 180, 0));

    }
}

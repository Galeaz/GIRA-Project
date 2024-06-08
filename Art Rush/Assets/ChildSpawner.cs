using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildSpawner : MonoBehaviour
{
    // Public variables to set in the Unity Editor
    public GameObject aiPrefab; // The AI character prefab to spawn
    public Transform[] spawnPoints; // Array of empty GameObjects as spawn points

    public void SpawnAICharacters()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            // Instantiate AI character at the position of the spawn point
            Instantiate(aiPrefab, spawnPoints[i].position, Quaternion.identity);
        }
    }
}

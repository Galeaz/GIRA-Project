using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildSpawner : MonoBehaviour
{
    // Public variables to set in the Unity Editor
    [SerializeField] private GameObject[] aiPrefabs; // The AI character prefab to spawn
    [SerializeField] private Transform[] spawnPoints; // Array of empty GameObjects as spawn points

    public void SpawnAICharacters()
    {
        int prefabNum = 0;
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (i % 3 == 0)
            {
                prefabNum = 0;
            }
            // Instantiate AI character at the position of the spawn point
            Instantiate(aiPrefabs[prefabNum], spawnPoints[i].position, Quaternion.identity);
            prefabNum++;
        }
    }
}

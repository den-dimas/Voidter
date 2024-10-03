using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;  // Array of different enemy prefabs
    public Transform[] spawnPoints;    // Array of spawn points
    public int killsRequiredToIncreaseDifficulty = 10; // Number of kills to increase difficulty
    public float initialSpawnDelay = 3f;  // Delay before first spawn
    public float initialSpawnInterval = 5f;  // Time between enemy spawns

    private int totalKills = 0;  // Total number of kills
    private int difficultyLevel = 1;  // Initial difficulty level
    private float spawnInterval;  // Current spawn interval

    void Start()
    {
        spawnInterval = initialSpawnInterval;
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(initialSpawnDelay);

        while (true)
        {
            SpawnEnemyBasedOnDifficulty();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemyBasedOnDifficulty()
    {
        // Adjust spawn interval and enemy variety based on difficulty
        if (totalKills >= difficultyLevel * killsRequiredToIncreaseDifficulty)
        {
            difficultyLevel++;
            spawnInterval = Mathf.Max(1f, initialSpawnInterval - (difficultyLevel * 0.5f)); // Decrease interval
        }

        // Select a random enemy prefab based on difficulty
        int enemyIndex = Random.Range(0, Mathf.Min(difficultyLevel, enemyPrefabs.Length));
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Instantiate(enemyPrefabs[enemyIndex], spawnPoint.position, spawnPoint.rotation);
    }

    // This method can be called from another script (e.g., enemy death) to increase the kill count
    public void OnEnemyKilled()
    {
        totalKills++;
    }
}

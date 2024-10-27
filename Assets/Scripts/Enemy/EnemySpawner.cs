using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy[] enemyVariants;

    public int killsRequiredToIncreaseDifficulty = 10;

    public float initialSpawnDelay = 3f;
    public float initialSpawnInterval = 5f;


    private int totalKills = 0;
    private int difficultyLevel = 1;

    private float spawnInterval;


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
        if (totalKills >= difficultyLevel * killsRequiredToIncreaseDifficulty)
        {
            difficultyLevel++;
            spawnInterval = Mathf.Max(1f, initialSpawnInterval - (difficultyLevel * 0.5f));
        }

        int enemyIndex = Random.Range(0, Mathf.Min(difficultyLevel, enemyVariants.Length));

        Vector2 spawnPoint = Camera.main.ViewportToWorldPoint(new(Random.Range(-0.05f, 1.05f), 1.05f));

        Instantiate(enemyVariants[enemyIndex], (Vector3)spawnPoint, Quaternion.identity);
    }


    public void OnEnemyKilled()
    {
        totalKills++;
    }
}

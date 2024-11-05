using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy[] enemyVariants;
    private List<Enemy> spawnedEnemies = new();

    [SerializeField] private float initialSpawnDelay = 3f;
    [SerializeField] private float initialSpawnInterval = 5f;

    private int difficultyLevel = 1;

    public int killLimit = 10;
    public int totalKills = 0;

    private float spawnInterval;

    void Start()
    {
        spawnInterval = initialSpawnInterval;

        SelectSpawnedEnemies();

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
        if (totalKills >= difficultyLevel * killLimit)
        {
            difficultyLevel++;

            spawnInterval = Mathf.Max(1f, initialSpawnInterval - (difficultyLevel * 0.5f));

            SelectSpawnedEnemies();
        }

        for (int i = 0; i < spawnedEnemies.Count; i++)
        {
            Enemy obj = Instantiate(spawnedEnemies[i]);

            obj.enemySpawner = this;
            obj.transform.parent = transform;
        }
    }

    public void OnEnemyKilled()
    {
        totalKills++;
    }

    private void SelectSpawnedEnemies()
    {
        spawnedEnemies.Clear();

        for (int i = 0; i < enemyVariants.Length; i++)
        {
            if (enemyVariants[i].GetLevel() <= difficultyLevel)
            {
                spawnedEnemies.Add(enemyVariants[i]);
            }
        }
    }
}
